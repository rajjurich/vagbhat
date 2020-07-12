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
    public class GetAssociationQueryAsyncHandler : IRequestHandler<GetAssociationQueryAsync, AssociationDto>
    {
        private readonly IAssociationService service;

        public GetAssociationQueryAsyncHandler(IAssociationService service)
        {
            this.service = service;
        }
        public async Task<AssociationDto> Handle(GetAssociationQueryAsync request, CancellationToken cancellationToken)
        {
            var result = await service.GetAsync(request.id);
            return result.ToAssociationDto();
        }
    }
}
