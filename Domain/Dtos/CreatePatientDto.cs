using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class CreatePatientDto
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string PatientHistory { get; set; }
        public string FullAddress { get; set; }
        public DateTime NextAppointmentDate { get; set; }
        public double Fees { get; set; }
        public string DoctorId { get; set; }        
        public string Complain { get; set; }        
        public string RxTreatment { get; set; }        
        public string Diagnosis { get; set; }
    }
}
