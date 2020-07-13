using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.MappingProfile
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
        }
    }
}
