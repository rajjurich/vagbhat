using Domain.Dtos;
using MediatR;

namespace Domain.Application.Commands
{
    public class EditRoleCommandAsync : IRequest<RoleDto>
    {
        public EditRoleCommandAsync(RoleDto dto)
        {
            Dto = dto;
        }

        public RoleDto Dto { get; }
    }
}