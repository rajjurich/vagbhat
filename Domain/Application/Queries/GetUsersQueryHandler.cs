using Domain.Dtos;
using Domain.Entities;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Queries
{
    public class GetUsersQueryHandler : RequestHandler<GetUsersQuery, IQueryable<UserDto>>
    {
        private readonly UserManager<User> userManager;
        private static readonly Expression<Func<User, UserDto>> AsUserDto =
            x => new UserDto
            {
                Email = x.Email,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName
            };

        public GetUsersQueryHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected override IQueryable<UserDto> Handle(GetUsersQuery request)
        {
            return userManager.Users.Select(AsUserDto);
        }
    }
}
