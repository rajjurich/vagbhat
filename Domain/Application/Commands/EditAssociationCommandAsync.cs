using Domain.Dtos;
using MediatR;

namespace Domain.Application.Commands
{
    public class EditAssociationCommandAsync : IRequest<AssociationDto>
    {
        public EditAssociationCommandAsync(AssociationDto dto)
        {
            Dto = dto;
        }

        public AssociationDto Dto { get; }
    }
}