using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Domain.Entities;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Domain.Application.Commands;
using Domain.Dtos;

namespace Domain.Services
{
    public interface IAccessService
    {
        Task<TokenDto> CreateTokenAsync(CreateTokenCommandAsync createTokenCommandAsync);
        Task<TokenDto> CreateRefreshTokenAsync(CreateRefreshTokenCommandAsync createRefreshCommandAsync);
    }

    public class AccessService : IAccessService
    {
        private readonly JwtSettings jwtSettings;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRefreshTokenService refreshTokenService;
        private readonly TokenValidationParameters tokenValidationParameters;

        public AccessService(JwtSettings jwtSettings
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
        public async Task<TokenDto> CreateTokenAsync(CreateTokenCommandAsync createTokenCommandAsync)
        {
            var user = await userManager.FindByEmailAsync(createTokenCommandAsync.AccessDto.Email);
            if (user == null)
            {
                return new TokenDto
                {
                    Errors = new[] { "Invalid Email" }
                };
            }

            var verifiedUser = await userManager
                .CheckPasswordAsync(user, createTokenCommandAsync.AccessDto.Password);

            if (!(verifiedUser))
            {
                return new TokenDto
                {
                    Errors = new[] { "Invalid Password" }
                };
            }

            return await GenerateToken(user);
        }

        public async Task<TokenDto> CreateRefreshTokenAsync(CreateRefreshTokenCommandAsync createRefreshCommandAsync)
        {
            var principal = GetClaimsPrincipal(createRefreshCommandAsync.RefreshDto.Access_Token);
            if (principal == null)
            {
                return new TokenDto
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
                return new TokenDto
                {
                    Errors = new[] { "Token is not expired" }
                };
            }

            var existingRefreshToken = await refreshTokenService
                .GetAsync(createRefreshCommandAsync.RefreshDto.Refresh_Token);
            if (existingRefreshToken == null)
            {
                return new TokenDto
                {
                    Errors = new[] { "Invalid Refresh Token" }
                };
            }

            if (existingRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                return new TokenDto
                {
                    Errors = new[] { "Refresh Token is expired" }
                };
            }

            if (existingRefreshToken.IsUsed)
            {
                return new TokenDto
                {
                    Errors = new[] { "Refresh Token is used" }
                };
            }

            if (existingRefreshToken.IsInvalid)
            {
                return new TokenDto
                {
                    Errors = new[] { "Refresh Token is invalid" }
                };
            }

            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (jti != existingRefreshToken.JwtId)
            {
                return new TokenDto
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
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
        }
        private async Task<TokenDto> GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetClaimsList(user)),
                Expires = DateTime.UtcNow.AddMinutes(GetTokenLifeTimeInMinutes()),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                , SecurityAlgorithms.HmacSha512)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var refreshToken = new RefreshToken
            {
                JwtId = token.Id,
                UserId = user.Id,
                CreatedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddDays(15),
            };

            await refreshTokenService.AddAsync(refreshToken);

            return new TokenDto
            {
                Access_Token = tokenHandler.WriteToken(token),
                Refresh_Token = refreshToken.Token
            };
        }

        private int GetTokenLifeTimeInMinutes()
        {
            Int32.TryParse(jwtSettings.TokenLifeTimeInMinutes, out int tokenLifeTimeInMinutes);

            tokenLifeTimeInMinutes = tokenLifeTimeInMinutes == 0 ? 2 : tokenLifeTimeInMinutes;
            return tokenLifeTimeInMinutes;
        }

        private async Task<List<Claim>> GetClaimsList(User user)
        {

            var claims = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("id", user.Id),
                new Claim("del", user.Deleted.ToString())
            };

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
