﻿using AutoMapper;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.MappingProfile
{
    public class RequestToDto : Profile
    {
        public RequestToDto()
        {
            CreateMap<AssociationRequest, AssociationDto>();

            CreateMap<AddRoleRequest, RoleDto>();
            CreateMap<UpdateRoleRequest, RoleDto>();

            CreateMap<AddUserRequest, UserDto>();
            CreateMap<UpdateUserRequest, UserDto>();
        }
    }
}