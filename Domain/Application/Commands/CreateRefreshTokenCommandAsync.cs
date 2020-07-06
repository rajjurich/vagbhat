using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateRefreshTokenCommandAsync : IRequest<TokenDto>
    {
        public CreateRefreshTokenCommandAsync(RefreshDto refreshDto)
        {
            RefreshDto = refreshDto;
        }

        public RefreshDto RefreshDto { get; }
    }
}
