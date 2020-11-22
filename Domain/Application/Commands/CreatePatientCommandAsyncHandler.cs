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
    public class CreatePatientCommandAsyncHandler : IRequestHandler<CreatePatientCommandAsync, PatientDto>
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
        public async Task<PatientDto> Handle(CreatePatientCommandAsync request
            , CancellationToken cancellationToken)
        {
            if (request.Dto.PatientId != null)
            {
                return await EditPatient(request);
            }
            else
            {
                return await CreatePatient(request);               
            }
        }

        private async Task<PatientDto> CreatePatient(CreatePatientCommandAsync request)
        {
            var patient = mapper.Map<Patient>(request.Dto);
            patient.UserId = httpContextAccessor.HttpContext.GetUserId();
            patient.UserId = "3c2c25df-23f3-4635-a3e4-c2e453eba7e2";
            patient.Gender = "m";
            //patient.DateOfBirth = Convert.ToDateTime(DateTime.Now
            //      .AddYears(-request.Dto.Age).ToShortDateString());
            Patient createdPatient = await patientService.AddAsync(patient);

            var address = mapper.Map<Address>(request.Dto);
            address.PatientId = createdPatient.PatientId;
            await addressService.AddAsync(address);

            var appointment = mapper.Map<Appointment>(request.Dto);
            appointment.AppointmentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            appointment.IsVisited = true;
            appointment.PatientId = createdPatient.PatientId;
            appointment.DoctorId = "00448D9A-AE9A-444D-968E-1DE50EF4BB2F";
            Appointment createdAppointment = await appointmentService.AddAsync(appointment);

            var newAppointment = new Appointment
            {
                AppointmentDate = request.Dto.NextAppointmentDate,
                PatientId = createdPatient.PatientId,
                DoctorId = "00448D9A-AE9A-444D-968E-1DE50EF4BB2F"
            };
            await appointmentService.AddAsync(newAppointment);

            var treatment = mapper.Map<Treatment>(request.Dto);
            treatment.TreatmentId = createdAppointment.AppointmentId;
            await treatmentService.AddAsync(treatment);

            return mapper.Map<PatientDto>(createdPatient);
        }
        private async Task<PatientDto> EditPatient(CreatePatientCommandAsync request)
        {
            //var patient = await patientService.GetAsync(request.Dto.Id);
            //if (patient != null)
            //{
            //    patient = mapper.Map<Patient>(request.Dto);
            //}
            var patient = mapper.Map<Patient>(request.Dto);
            patient.UserId = httpContextAccessor.HttpContext.GetUserId();
            patient.UserId = "3c2c25df-23f3-4635-a3e4-c2e453eba7e2";
            patient.Gender = "m";
            //patient.DateOfBirth = Convert.ToDateTime(DateTime.Now
            //      .AddYears(-request.Dto.Age).ToShortDateString());
            Patient createdPatient = await patientService.UpdateAsync(patient);

            
            var address = mapper.Map<Address>(request.Dto);
            
            await addressService.UpdateAsync(address);

            //var getappointment = appointmentService
            //    .Find(x => x.PatientId == patient.Id && x.IsVisited == false, 0, 1)
            //    .FirstOrDefault();

            var appointment = mapper.Map<Appointment>(request.Dto);

            //appointment.Id = getappointment.Id;
            appointment.AppointmentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            appointment.IsVisited = true;
            appointment.PatientId = createdPatient.PatientId;
            appointment.DoctorId = "00448D9A-AE9A-444D-968E-1DE50EF4BB2F";
            Appointment createdAppointment = await appointmentService.UpdateAsync(appointment);


            var newAppointment = new Appointment
            {
                AppointmentDate = request.Dto.NextAppointmentDate,
                PatientId = createdPatient.PatientId,
                DoctorId = "00448D9A-AE9A-444D-968E-1DE50EF4BB2F"
            };
            await appointmentService.AddAsync(newAppointment);

            var treatment = mapper.Map<Treatment>(request.Dto);
            treatment.TreatmentId = createdAppointment.AppointmentId;
            await treatmentService.AddAsync(treatment);

            return mapper.Map<PatientDto>(createdPatient);
        }
    }
}
