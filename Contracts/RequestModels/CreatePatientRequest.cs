using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.RequestModels
{
    public class CreatePatientRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(250, ErrorMessage = "Exceeded Length")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        public int Age { get; set; }
        [StringLength(15, ErrorMessage = "Mobile NumberExceeded Length")]
        public string MobileNumber { get; set; }
        [StringLength(15, ErrorMessage = "Gender Exceeded Length")]
        public string Gender { get; set; }
        [StringLength(500, ErrorMessage = "Patient History Exceeded Length")]
        public string PatientHistory { get; set; }
        [StringLength(500, ErrorMessage = "Full Address Exceeded Length")]
        public string FullAddress { get; set; }
        public DateTime NextAppointmentDate { get; set; }
        public double Fees { get; set; }
        public string DoctorId { get; set; }
        [StringLength(500, ErrorMessage = "Complain Exceeded Length")]
        public string Complain { get; set; }
        [StringLength(500, ErrorMessage = "RxTreatment Exceeded Length")]
        public string RxTreatment { get; set; }
        [StringLength(500, ErrorMessage = "Diagnosis Exceeded Length")]
        public string Diagnosis { get; set; }
    }
}
