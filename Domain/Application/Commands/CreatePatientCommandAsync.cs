using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Application.Commands
{
    public class CreatePatientCommandAsync : IRequest<CreatePatientDto>
    {
        public CreatePatientCommandAsync(CreatePatientDto dto)
        {
            Dto = dto;
        }

        public CreatePatientDto Dto { get; }
    }
}
