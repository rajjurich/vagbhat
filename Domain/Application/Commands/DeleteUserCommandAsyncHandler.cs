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
    public class DeleteUserCommandAsyncHandler : IRequestHandler<DeleteUserCommandAsync, UserDto>
    {
        private readonly IUserService service;

        public DeleteUserCommandAsyncHandler(IUserService service)
        {
            this.service = service;
        }
        public async Task<UserDto> Handle(DeleteUserCommandAsync request, CancellationToken cancellationToken)
        {
            return await service.RemoveAsync(request.Id);
        }
    }
}
