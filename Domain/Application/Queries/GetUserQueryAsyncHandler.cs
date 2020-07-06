using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Queries
{
    public class GetUserQueryAsyncHandler : IRequestHandler<GetUserQueryAsync, UserDto>
    {        
        private readonly UserManager<User> userManager;

        public GetUserQueryAsyncHandler(UserManager<User> userManager)
        {            
            this.userManager = userManager;
        }
        public async Task<UserDto> Handle(GetUserQueryAsync request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.id);
            return user.ToUserDto();
        }
    }
}
