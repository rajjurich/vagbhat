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
    public class GetUserQueryAsyncHandler : IRequestHandler<GetUserQueryAsync, UserDto>
    {
        private readonly IUserService service;

        public GetUserQueryAsyncHandler(IUserService service)
        {
            this.service = service;
        }
        public async Task<UserDto> Handle(GetUserQueryAsync request, CancellationToken cancellationToken)
        {            
            return await service.GetAsync(request.id);
        }
    }
}
