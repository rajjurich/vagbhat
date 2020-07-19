using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Options;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class DeleteRoleCommandAsyncHandler : IRequestHandler<DeleteRoleCommandAsync, RoleDto>
    {
        private readonly IRoleService service;

        public DeleteRoleCommandAsyncHandler(IRoleService service)
        {
            this.service = service;
        }
        public async Task<RoleDto> Handle(DeleteRoleCommandAsync request, CancellationToken cancellationToken)
        {
            return await service.RemoveAsync(request.Id);
        }
    }
}
