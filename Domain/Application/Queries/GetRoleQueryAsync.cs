using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Queries
{
    public class GetRoleQueryAsync : IRequest<RoleDto>
    {
        public readonly string id;

        public GetRoleQueryAsync(string id)
        {
            this.id = id;
        }
    }
}
