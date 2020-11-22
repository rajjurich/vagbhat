using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.MappingProfile
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<RoleDto, Role>();
            CreateMap<UserDto, User>();

            CreateMap<PatientDto, Patient>().ForMember(d => d.DateOfBirth,
                o => o.MapFrom(s => Convert.ToDateTime(DateTime.Now
                  .AddYears(-s.Age).ToShortDateString())));
            CreateMap<PatientDto, Address>();
            CreateMap<PatientDto, Appointment>();
            CreateMap<PatientDto, Treatment>();
        }
    }
}
