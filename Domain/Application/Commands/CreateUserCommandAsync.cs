using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateUserCommandAsync : IRequest<UserDto>
    {
        public CreateUserCommandAsync(UserDto dto)
        {
            Dto = dto;
        }

        public UserDto Dto { get; }
    }
}
