﻿using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.MappingProfile
{
    public class DtoToEntity:Profile
    {
        public DtoToEntity()
        {            
            CreateMap<RoleDto, Role>();
            CreateMap<UserDto, User>();

            CreateMap<CreatePatientDto, Patient>();
            CreateMap<CreatePatientDto, Address>();
            CreateMap<CreatePatientDto, Appointment>();
            CreateMap<CreatePatientDto, Treatment>();
        }
    }
}
