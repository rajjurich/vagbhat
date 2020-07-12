using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Queries
{
    public class GetAssociationQueryAsync : IRequest<AssociationDto>
    {
        public readonly string id;

        public GetAssociationQueryAsync(string id)
        {
            this.id = id;
        }
    }
}
