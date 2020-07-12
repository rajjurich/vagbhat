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
    public class GetAssociationsQueryHandler : RequestHandler<GetAssociationsQuery, IQueryable<AssociationDto>>
    {
        private readonly IAssociationService service;
        private static readonly Expression<Func<Association, AssociationDto>> AsAssociationDto =
          x => new AssociationDto
          {
              Id = x.Id,
              AssociationName = x.AssociationName
          };

        public GetAssociationsQueryHandler(IAssociationService service)
        {
            this.service = service;
        }

        protected override IQueryable<AssociationDto> Handle(GetAssociationsQuery request)
        {
            return service.Get(0, 10).Select(AsAssociationDto);
        }


    }
}
