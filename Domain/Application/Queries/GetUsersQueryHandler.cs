using Domain.Application.Queries;
using Domain.Model;
using Domain.Services;
using MediatR;
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
        private readonly IUserService userService;

        public GetUsersQueryHandler(IUserService userService)
        {
            this.userService = userService;
        }

        protected override IQueryable<User> Handle(GetUsersQuery request)
        {
            return userService.Get();
        }        
    }
}
