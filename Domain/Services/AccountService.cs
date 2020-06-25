using Models.RequestModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Models.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Models.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Domain.Model;

namespace Domain.Services
{
    public interface IAccountService
    {
        Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel);
    }

    public class AccountService : IAccountService
    {
        private readonly JwtSettings jwtSettings;
        private readonly UserManager<User> userManager;

        public AccountService(JwtSettings jwtSettings, UserManager<User> userManager)
        {
            this.jwtSettings = jwtSettings;
            this.userManager = userManager;
        }
        public async Task<LoginResponseModel> Login(LoginRequestModel loginRequestModel)
        {
            var user = await userManager.FindByEmailAsync(loginRequestModel.Email);
            if (user == null)
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Invalid User" }
                };
            }

            var verifiedUser = await userManager.CheckPasswordAsync(user, loginRequestModel.Password);

            if (!(verifiedUser))
            {
                return new LoginResponseModel
                {
                    Success = false,
                    Errors = new[] { "Invalid User" }
                };
            }

            return GenerateToken(loginRequestModel);
        }

        private LoginResponseModel GenerateToken(LoginRequestModel loginRequestModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,loginRequestModel.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,loginRequestModel.Email),
                    new Claim("id","123")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseModel
            {
                Success = true,
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
