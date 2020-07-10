using Domain.Dtos;
using Domain.Entities;
using Domain.Options;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Extensions;

namespace Domain.Application.Queries
{
    public class GetUsersQueryHandler : RequestHandler<GetUsersQuery, IQueryable<UserDto>>
    {
        private readonly IUserService userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected override IQueryable<UserDto> Handle(GetUsersQuery request)
        {
            return userService.Get(0,10);
        }

        
    }
}
