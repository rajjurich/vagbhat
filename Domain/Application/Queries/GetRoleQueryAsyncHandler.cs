using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Queries
{
    public class GetRoleQueryAsyncHandler : IRequestHandler<GetRoleQueryAsync, RoleDto>
    {
        private readonly IRoleService service;

        public GetRoleQueryAsyncHandler(IRoleService service)
        {
            this.service = service;
        }
        public async Task<RoleDto> Handle(GetRoleQueryAsync request, CancellationToken cancellationToken)
        {            
            return await service.GetAsync(request.id);
        }
    }
}
