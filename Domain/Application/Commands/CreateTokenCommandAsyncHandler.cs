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
    public class CreateTokenCommandAsyncHandler : IRequestHandler<CreateTokenCommandAsync, Token>
    {
        private readonly IUserService userService;

        public CreateTokenCommandAsyncHandler(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<Token> Handle(CreateTokenCommandAsync request, CancellationToken cancellationToken)
        {
            return await userService.CreateTokenAsync(request);
        }
    }
}
