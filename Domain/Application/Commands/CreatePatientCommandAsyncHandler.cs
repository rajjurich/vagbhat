using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Extensions;
using Domain.Options;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Application.Commands
{
    public class CreatePatientCommandAsyncHandler : IRequestHandler<CreatePatientCommandAsync, CreatePatientDto>
    {
        private readonly IPatientService patientService;
        private readonly IAddressService addressService;
        private readonly IAppointmentService appointmentService;
        private readonly ITreatmentService treatmentService;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreatePatientCommandAsyncHandler(IPatientService patientService
            , IAddressService addressService
            , IAppointmentService appointmentService
            , ITreatmentService treatmentService
            , IMapper mapper
            , IHttpContextAccessor httpContextAccessor)
        {
            this.patientService = patientService;
            this.addressService = addressService;
            this.appointmentService = appointmentService;
            this.treatmentService = treatmentService;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<CreatePatientDto> Handle(CreatePatientCommandAsync request
            , CancellationToken cancellationToken)
        {
            var patient = mapper.Map<Patient>(request.Dto);
            patient.UserId = httpContextAccessor.HttpContext.GetUserId();
            patient.UserId = "3ec12f1b-ac55-4053-8e2c-6aa4ae99fc6b";
            patient.DateOfBirth = Convert.ToDateTime(DateTime.Now
                .AddYears(-request.Dto.Age).ToShortDateString());
            var createdPatient = await patientService.AddAsync(patient);

            var address = mapper.Map<Address>(request.Dto);
            address.PatientId = createdPatient.Id;
            await addressService.AddAsync(address);

            var appointment = mapper.Map<Appointment>(request.Dto);
            appointment.AppointmentDate = DateTime.Now;
            appointment.IsVisited = true;
            appointment.PatientId = createdPatient.Id;
            appointment.DoctorId = "00448D9A-AE9A-444D-968E-1DE50EF4BB2F";
            var createdAppointment = await appointmentService.AddAsync(appointment);

            var newAppointment = new Appointment
            {
                AppointmentDate = request.Dto.NextAppointmentDate,
                PatientId = createdPatient.Id,
                DoctorId = "00448D9A-AE9A-444D-968E-1DE50EF4BB2F"
            };
            await appointmentService.AddAsync(newAppointment);

            var treatment = mapper.Map<Treatment>(request.Dto);
            treatment.Id = createdAppointment.Id;
            await treatmentService.AddAsync(treatment);

            return mapper.Map<CreatePatientDto>(createdPatient);
        }
    }
}
