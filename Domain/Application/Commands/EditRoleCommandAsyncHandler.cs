using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class EditRoleCommandAsyncHandler : IRequestHandler<EditRoleCommandAsync, RoleDto>
    {
        private readonly IRoleService service;

        public EditRoleCommandAsyncHandler(IRoleService service)
        {
            this.service = service;
        }
        public async Task<RoleDto> Handle(EditRoleCommandAsync request, CancellationToken cancellationToken)
        {
            return await service.UpdateAsync(request.Dto);
        }
    }
}
