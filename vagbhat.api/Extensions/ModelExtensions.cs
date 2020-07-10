using Contracts.User.RequestModels;
using Contracts.ResponseModels;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.RequestModels;

namespace vagbhat.api.Extensions
{
    public static class ModelExtensions
    {
        public static UserResponse ToUserResponse(this UserDto dto)
        {
            return new UserResponse()
            {
                Email = dto.Email,
                Id = dto.Id,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName,
                IsDeleted = dto.IsDeleted
            };
        }

        public static UserDto ToUserDto(this CreateUserRequest request)
        {
            return new UserDto()
            {
                Email = request.Email,
                Password = request.Password,
                PhoneNumber = request.PhoneNumber,
                UserName = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName
            };
        }

        public static UserDto ToUserDto(this EditUserRequest request)
        {
            return new UserDto()
            {
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
        }
    }
}
