using AutoMapper;
using Contracts.RequestModels;
using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.web.MappingProfile
{
    public class ResponseToRequest : Profile
    {
        public ResponseToRequest()
        {
            CreateMap<PatientResponse, CreatePatientRequest>();
        }
    }
}
