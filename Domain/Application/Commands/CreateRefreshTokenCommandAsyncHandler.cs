using Contracts.RequestModels;
using Contracts.ResponseModels;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class CreateRefreshTokenCommandAsyncHandler : IRequestHandler<CreateRefreshTokenCommandAsync, Token>
    {
        private readonly IUserService userService;

        public CreateRefreshTokenCommandAsyncHandler(IUserService userService)
        {
            this.userService = userService;
        }

        

        public async Task<Token> Handle(CreateRefreshTokenCommandAsync request, CancellationToken cancellationToken)
        {
            return await userService.CreateRefreshTokenAsync(request);
        }
    }
}
