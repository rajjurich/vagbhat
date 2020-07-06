using Domain.Dtos;
using MediatR;

namespace Domain.Application.Commands
{
    public class EditUserCommandAsync : IRequest<UserDto>
    {
        public EditUserCommandAsync(UserDto userDto)
        {
            UserDto = userDto;
        }

        public UserDto UserDto { get; }
    }
}