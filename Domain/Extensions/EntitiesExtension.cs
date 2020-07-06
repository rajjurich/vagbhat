using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class EntitiesExtension
    {
        public static UserDto ToUserDto(this User entity)
        {
            return new UserDto()
            {
                Id = entity.Id,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,                
                UserName = entity.UserName
            };
        }
    }
}
