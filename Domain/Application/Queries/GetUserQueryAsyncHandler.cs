using Domain.Entities;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Queries
{
    public class GetUserQueryAsyncHandler : IRequestHandler<GetUserQueryAsync, User>
    {        
        private readonly UserManager<User> userManager;

        public GetUserQueryAsyncHandler(UserManager<User> userManager)
        {            
            this.userManager = userManager;
        }
        public async Task<User> Handle(GetUserQueryAsync request, CancellationToken cancellationToken)
        {
            return await userManager.FindByIdAsync(request.id);
        }
    }
}
