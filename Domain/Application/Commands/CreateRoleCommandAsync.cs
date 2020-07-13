using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateRoleCommandAsync : IRequest<RoleDto>
    {
        public CreateRoleCommandAsync(RoleDto dto)
        {
            Dto = dto;
        }

        public RoleDto Dto { get; }
    }
}
