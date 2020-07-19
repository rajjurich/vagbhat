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
    public class EditUserCommandAsyncHandler : IRequestHandler<EditUserCommandAsync, UserDto>
    {
        private readonly IUserService service;

        public EditUserCommandAsyncHandler(IUserService service)
        {
            this.service = service;
        }
        public async Task<UserDto> Handle(EditUserCommandAsync request, CancellationToken cancellationToken)
        {
            return await service.UpdateAsync(request.Dto);
        }
    }
}
