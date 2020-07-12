using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreateAssociationCommandAsync : IRequest<AssociationDto>
    {
        public CreateAssociationCommandAsync(AssociationDto dto)
        {
            Dto = dto;
        }

        public AssociationDto Dto { get; }
    }
}
