using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreatePatientCommandAsync : IRequest<PatientDto>
    {
        public CreatePatientCommandAsync(PatientDto dto)
        {
            Dto = dto;
        }

        public PatientDto Dto { get; }
    }
}
