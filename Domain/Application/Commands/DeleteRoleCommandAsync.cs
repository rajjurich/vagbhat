using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class DeleteRoleCommandAsync: IRequest<RoleDto>
    {
        public DeleteRoleCommandAsync(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
