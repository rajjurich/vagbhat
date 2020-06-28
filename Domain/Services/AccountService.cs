using Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Models.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Domain.Model;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace Domain.Services
{
    public interface IAccountService
    {
        Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel);
        Task<LoginResponseModel> RefreshTokenAsync(string token, string refreshToken);
    }

    public class AccountService : IAccountService
    {
        private readonly JwtSettings jwtSettings;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IRefreshTokenService refreshTokenService;
        private readonly TokenValidationParameters tokenValidationParameters;

        public AccountService(JwtSettings jwtSettings
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
        public async Task<LoginResponseModel> LoginAsync(LoginRequestModel loginRequestModel)
        {
            var user = await userManager.FindByEmailAsync(loginRequestModel.Email);
            if (user == null)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Invalid Email" }
                };
            }

            var verifiedUser = await userManager.CheckPasswordAsync(user, loginRequestModel.Password);

            if (!(verifiedUser))
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Invalid Password" }
                };
            }

            return await GenerateToken(user);
        }

        public async Task<LoginResponseModel> RefreshTokenAsync(string token, string refreshToken)
        {
            var principal = GetClaimsPrincipal(token);
            if (principal == null)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Invalid Token" }
                };
            }

            var tokenExpiryDateUnix =
               long.Parse(principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Exp).Value);

            DateTime tokenExpiryDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)
                .AddSeconds(tokenExpiryDateUnix);

            if (tokenExpiryDate > DateTime.UtcNow)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Token is not expired" }
                };
            }

            var existingRefreshToken = await refreshTokenService.GetAsync(refreshToken);
            if (existingRefreshToken == null)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Invalid Refresh Token" }
                };
            }

            if (existingRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Refresh Token is expired" }
                };
            }

            if (existingRefreshToken.IsUsed)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Refresh Token is used" }
                };
            }

            if (existingRefreshToken.IsInvalid)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Refresh Token is invalid" }
                };
            }

            var jti = principal.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (jti != existingRefreshToken.JwtId)
            {
                return new LoginResponseModel
                {
                    Success = false,
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
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
        private async Task<LoginResponseModel> GenerateToken(User user)
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
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

            return new LoginResponseModel
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                RefreshToken = refreshToken.Token
            };
        }

        private async Task<List<Claim>> GetClaimsList(User user)
        {
            
            var claims = new List<Claim>(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    //new Claim(ClaimTypes.Name,user.UserName),
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
