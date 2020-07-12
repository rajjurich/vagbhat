using Domain.Dtos;
using MediatR;

namespace Domain.Application.Commands
{
    public class EditUserCommandAsync : IRequest<UserDto>
    {
        public EditUserCommandAsync(UserDto dto)
        {
            Dto = dto;
        }

        public UserDto Dto { get; }
    }
}