using AutoMapper;
using Contracts.ResponseModels;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.MappingProfile
{
    public class DtoToResponse : Profile
    {
        public DtoToResponse()
        {                   
            CreateMap<RoleDto, RoleResponse>();
            CreateMap<UserDto, UserResponse>();
        }
    }
    
}
