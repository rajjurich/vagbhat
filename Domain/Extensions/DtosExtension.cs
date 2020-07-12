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
            var entity = new User()
            {
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                UserName = dto.UserName
            };

            if (!(string.IsNullOrWhiteSpace(dto.Id)))
            {
                entity.Id = dto.Id;
            }
            return entity;

        }

        public static Association ToAssociation(this AssociationDto dto)
        {
            var entity = new Association()
            {
                AssociationName = dto.AssociationName
            };

            if (!(string.IsNullOrWhiteSpace(dto.Id)))
            {
                entity.Id = dto.Id;
            }
            return entity;

        }
    }
}
