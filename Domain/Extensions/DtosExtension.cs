using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class DtosExtension
    {
        public static User ToUser(this UserDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName
            };

            if (!(string.IsNullOrWhiteSpace(dto.Id)))
            {
                user.Id = dto.Id;
            }
            return user;

        }
    }
}
