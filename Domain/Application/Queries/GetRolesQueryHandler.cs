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
    public class GetRolesQueryHandler : RequestHandler<GetRolesQuery, IQueryable<RoleDto>>
    {
        private readonly IRoleService service;

        public GetRolesQueryHandler(IRoleService service)
        {
            this.service = service;
        }

        protected override IQueryable<RoleDto> Handle(GetRolesQuery request)
        {
            return service.Get(0,10);
        }

        
    }
}
