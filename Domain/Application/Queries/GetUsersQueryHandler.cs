using Domain.Entities;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Queries
{
    public class GetUsersQueryHandler : RequestHandler<GetUsersQuery, IQueryable<User>>
    {
        private readonly UserManager<User> userManager;

        public GetUsersQueryHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        protected override IQueryable<User> Handle(GetUsersQuery request)
        {
            return userManager.Users;
        }        
    }
}
