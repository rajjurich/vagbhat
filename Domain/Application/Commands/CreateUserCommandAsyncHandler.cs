using Domain.Dtos;
using Domain.Entities;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class CreateUserCommandAsyncHandler : IRequestHandler<CreateUserCommandAsync, UserDto>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public CreateUserCommandAsyncHandler(UserManager<User> userManager
            , RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<UserDto> Handle(CreateUserCommandAsync request, CancellationToken cancellationToken)
        {
            var existingUser = await userManager.FindByEmailAsync(request.UserDto.Email);
            if (existingUser != null)
            {
                return new UserDto
                {
                    Errors = new string[] { "Email already exists" }
                };
            }

            var user = new User
            {
                Email = request.UserDto.Email,
                UserName = request.UserDto.Email
            };

            var createdUser = await userManager.CreateAsync(user, request.UserDto.Password);
            if (!(createdUser.Succeeded))
            {
                return new UserDto
                {
                    Errors = createdUser.Errors.Select(x => x.Description).ToArray()
                };
            }

            Claim userClaim = new Claim(ClaimTypes.NameIdentifier, user.UserName);

            await userManager.AddClaimAsync(user, userClaim);

            List<string> roles = await GetRolesFromRolesDto(request);

            await userManager.AddToRolesAsync(user, roles);

            

            

            foreach (var role in roles)
            {

                
                //claims.Add(new Claim(ClaimTypes.Role, userRole));
                //var role = await roleManager.FindByNameAsync(userRole);
                //if (role != null)
                //{
                //    var roleClaims = await roleManager.GetClaimsAsync(role);
                //    foreach (Claim roleClaim in roleClaims)
                //    {
                //        claims.Add(roleClaim);
                //    }
                //}
            }

            

            
        }

        private async Task<List<string>> GetRolesFromRolesDto(CreateUserCommandAsync request)
        {
            List<string> roles = new List<string>();
            List<Claim> roleClaims = new List<Claim>();
            var rolesDto = request.UserDto.Roles;

            foreach (var roleDto in rolesDto)
            {
                if (await roleManager.RoleExistsAsync(roleDto.RoleName))
                {
                    Claim roleClaim = new Claim(ClaimTypes.Role, roleDto.RoleName);
                    await roleManager
                        .AddClaimAsync(await roleManager
                        .FindByNameAsync(roleDto.RoleName), roleClaim);
                    roles.Add(roleDto.RoleName);
                }
            }

            return roles;
        }
    }
}
