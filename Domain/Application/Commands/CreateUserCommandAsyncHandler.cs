using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
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

        public CreateUserCommandAsyncHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<UserDto> Handle(CreateUserCommandAsync request, CancellationToken cancellationToken)
        {
            var user = request.UserDto.ToUser();
            user.Deleted = false;
            var result = await userManager.CreateAsync(user, request.UserDto.Password);

            if (!(result.Succeeded))
            {
                return new UserDto
                {
                    Errors = result.Errors.Select(x => x.Description).ToArray()
                };
            }

            List<Claim> userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));            

            await userManager.AddClaimsAsync(user, userClaims);

            var createdUser = await userManager.FindByEmailAsync(user.Email);

            return createdUser.ToUserDto();
        }
    }
}
