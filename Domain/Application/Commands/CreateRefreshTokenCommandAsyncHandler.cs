using Domain.Core;
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
    public class CreateRefreshTokenCommandAsyncHandler : IRequestHandler<CreateRefreshTokenCommandAsync, TokenDto>
    {
        private readonly IAccessService accessService;
        

        public CreateRefreshTokenCommandAsyncHandler(IAccessService accessService)
        {
            this.accessService = accessService;            
        }        

        public async Task<TokenDto> Handle(CreateRefreshTokenCommandAsync request, CancellationToken cancellationToken)
        {
            return await accessService.CreateRefreshTokenAsync(request);
        }
    }
}
