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
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private static readonly Expression<Func<User, UserDto>> AsUserDto =
            x => new UserDto
            {
                Email = x.Email,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName
            };

        public GetUsersQueryHandler(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override IQueryable<UserDto> Handle(GetUsersQuery request)
        {
            var accessId = httpContextAccessor.HttpContext.GetUserId();
            return (checkRole(accessId).Result) ?
                userManager.Users.Select(AsUserDto) :
                userManager.Users.Where(x => x.Association.AssociationName != "self").Select(AsUserDto);
        }

        private async Task<bool> checkRole(string id)
        {
            return await userManager.IsInRoleAsync(await userManager.FindByIdAsync(id), AllowedRoles.Super);
        }
    }
}
