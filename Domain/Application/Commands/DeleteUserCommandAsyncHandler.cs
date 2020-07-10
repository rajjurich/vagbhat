using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Options;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class DeleteUserCommandAsyncHandler : IRequestHandler<DeleteUserCommandAsync, UserDto>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public DeleteUserCommandAsyncHandler(UserManager<User> userManager
            , RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<UserDto> Handle(DeleteUserCommandAsync request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id);

            if (user == null)
            {
                return new UserDto
                {
                    Errors = new string[] { $"User not found with id == {request.Id}" }
                };
            }

            if (await userManager.IsInRoleAsync(user, AllowedRoles.Super))
            {
                return new UserDto
                {
                    Errors = new string[] { $"User cannot be deleted with id == {request.Id}" }
                };
            }

            var result = await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            result = await userManager.RemoveFromRolesAsync(user, await userManager.GetRolesAsync(user));

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }
            
            user.Deleted = true;

            result = await userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            return user.ToUserDto();
        }
    }
}
