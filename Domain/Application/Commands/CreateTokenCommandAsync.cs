using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateTokenCommandAsync : IRequest<TokenDto>
    {
        public CreateTokenCommandAsync(AccessDto accessDto)
        {
            AccessDto = accessDto;
        }
        
        public AccessDto AccessDto { get; }
    }
}
