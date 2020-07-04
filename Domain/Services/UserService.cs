using Contracts.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Contracts.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Contracts.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Domain.Model;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Domain.Application.Commands;

namespace Domain.Services
{
    public interface IUserService
    {
        Task<Token> CreateTokenAsync(CreateTokenCommandAsync createTokenCommandAsync);
        Task<Token> CreateRefreshTokenAsync(CreateRefreshTokenCommandAsync createRefreshCommandAsync);
        IQueryable<User> Get();
        Task<User> Get(string id);
    }

    public class UserService : IUserService
    {
        private readonly JwtSettings jwtSettings;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRefreshTokenService refreshTokenService;
        private readonly TokenValidationParameters tokenValidationParameters;

        public UserService(JwtSettings jwtSettings
            , UserManager<User> userManager
            , RoleManager<Role> roleManager
            , IRefreshTokenService refreshTokenService
            , TokenValidationParameters tokenValidationParameters)
        {
            this.jwtSettings = jwtSettings;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.refreshTokenService = refreshTokenService;
            this.tokenValidationParameters = tokenValidationParameters;
        }
        public async Task<Token> CreateTokenAsync(CreateTokenCommandAsync createTokenCommandAsync)
        {
            var user = await userManager.FindByEmailAsync(createTokenCommandAsync.TokenRequestModel.Email);
            if (user == null)
            {
                return new Token
                {
                    Errors = new[] { "Invalid Email" }
                };
            }

            var verifiedUser = await userManager
                .CheckPasswordAsync(user, createTokenCommandAsync.TokenRequestModel.Password);

            if (!(verifiedUser))
            {
                return new Token
                {
                    Errors = new[] { "Invalid Password" }
                };
            }

            return await GenerateToken(user);
        }

        public async Task<Token> CreateRefreshTokenAsync(CreateRefreshTokenCommandAsync createRefreshCommandAsync)
        {
            var principal = GetClaimsPrincipal(createRefreshCommandAsync.RefreshRequestModel.Access_Token);
            if (principal == null)
            {
                return new Token
                {
                    Errors = new[] { "Invalid Token" }
                };
            }

            var tokenExpiryDateUnix =
               long.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            DateTime tokenExpiryDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(tokenExpiryDateUnix);

            if (tokenExpiryDate > DateTime.UtcNow)
            {
                return new Token
                {
                    Errors = new[] { "Token is not expired" }
                };
            }

            var existingRefreshToken = await refreshTokenService
                .GetAsync(createRefreshCommandAsync.RefreshRequestModel.Refresh_Token);
            if (existingRefreshToken == null)
            {
                return new Token
                {
                    Errors = new[] { "Invalid Refresh Token" }
                };
            }

            if (existingRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                return new Token
                {
                    Errors = new[] { "Refresh Token is expired" }
                };
            }

            if (existingRefreshToken.IsUsed)
            {
                return new Token
                {
                    Errors = new[] { "Refresh Token is used" }
                };
            }

            if (existingRefreshToken.IsInvalid)
            {
                return new Token
                {
                    Errors = new[] { "Refresh Token is invalid" }
                };
            }

            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (jti != existingRefreshToken.JwtId)
            {
                return new Token
                {
                    Errors = new[] { "Invalid Token" }
                };
            }

            existingRefreshToken.IsUsed = true;
            await refreshTokenService.EditAsync(existingRefreshToken);

            var id = principal.Claims.Single(x => x.Type == "id").Value;
            var user = await userManager.FindByIdAsync(id);
            return await GenerateToken(user);
        }

        public IQueryable<User> Get()
        {
            return userManager.Users;
        }

        public async Task<User> Get(string id)
        {
            return await userManager.FindByIdAsync(id);
        }
        private ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
                return IsJwtWithValidSecurityAlgoritm(securityToken) ? principal : null;
            }
            catch
            {
                return null;
            }

        }

        private bool IsJwtWithValidSecurityAlgoritm(SecurityToken securityToken)
        {
            return (securityToken is JwtSecurityToken jwtSecurityToken) &&
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
        private async Task<Token> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            Int32.TryParse(jwtSettings.TokenLifeTimeInMinutes, out int tokenLifeTimeInMinutes);

            tokenLifeTimeInMinutes = tokenLifeTimeInMinutes == 0 ? 2 : tokenLifeTimeInMinutes;

            List<Claim> claims = await GetClaimsList(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(tokenLifeTimeInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(1),
            };

            await refreshTokenService.AddAsync(refreshToken);

            return new Token
            {
                Access_Token = tokenHandler.WriteToken(token),
                Refresh_Token = refreshToken.Token
            };
        }

        private async Task<List<Claim>> GetClaimsList(User user)
        {

            var claims = new List<Claim>(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim("id",user.Id)
                });


            var userClaims = await userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                //claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }

    }
}
