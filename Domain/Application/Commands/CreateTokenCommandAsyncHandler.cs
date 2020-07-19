using Domain.Dtos;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class CreateTokenCommandAsyncHandler : IRequestHandler<CreateTokenCommandAsync, TokenDto>
    {
        private readonly IAccessService userService;

        public CreateTokenCommandAsyncHandler(IAccessService userService)
        {
            this.userService = userService;
        }
        public async Task<TokenDto> Handle(CreateTokenCommandAsync request, CancellationToken cancellationToken)
        {
            return await userService.CreateTokenAsync(request);
        }
    }
}
