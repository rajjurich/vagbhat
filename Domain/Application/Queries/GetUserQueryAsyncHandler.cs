using Domain.Model;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Queries
{
    public class GetUserQueryAsyncHandler : IRequestHandler<GetUserQueryAsync, User>
    {
        private readonly IUserService userService;

        public GetUserQueryAsyncHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<User> Handle(GetUserQueryAsync request, CancellationToken cancellationToken)
        {
            return await userService.Get(request.id);
        }
    }
}
