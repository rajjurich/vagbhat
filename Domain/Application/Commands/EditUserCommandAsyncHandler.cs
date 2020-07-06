using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
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
    public class EditUserCommandAsyncHandler : IRequestHandler<EditUserCommandAsync, UserDto>
    {
        private readonly UserManager<User> userManager;

        public EditUserCommandAsyncHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<UserDto> Handle(EditUserCommandAsync request, CancellationToken cancellationToken)
        {
            //var existingUser = await GetExistingUser(request);

            //if (!(string.IsNullOrEmpty(existingUser)))
            //{
            //    return new UserDto
            //    {
            //        Errors = new string[] { existingUser }
            //    };
            //}

            var user = request.UserDto.ToUserDto();

            var result = await userManager.UpdateAsync(user);

            if (!(result.Succeeded))
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));
            Claim userClaim = new Claim(ClaimTypes.NameIdentifier, user.UserName);
            await userManager.AddClaimAsync(user, userClaim);

            var updatedUser = await userManager.FindByEmailAsync(user.Email);

            return updatedUser.ToUserDto();
        }

        private async Task<string> GetExistingUser(EditUserCommandAsync request)
        {
            return await userManager.FindByEmailAsync(request.UserDto.Email) != null ?
                "Email already exists" : await userManager.FindByNameAsync(request.UserDto.UserName) != null ?
                "UserName already exists" : string.Empty;
        }
    }
}
