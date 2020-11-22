using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Contracts.CustomValidation;

namespace Contracts.RequestModels
{
    public class CreatePatientRequest
    {
        public string PatientId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(250, ErrorMessage = "Exceeded Length")]
        public string PatientName { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(1, 200, ErrorMessage = "Incorrect Age")]
        public int Age { get; set; }
        [Required(ErrorMessage ="Mobile Number is required")]
        [StringLength(15, ErrorMessage = "Mobile NumberExceeded Length")]
        public string MobileNumber { get; set; }
        [StringLength(15, ErrorMessage = "Gender Exceeded Length")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Patient History is required")]
        [StringLength(500, ErrorMessage = "Patient History Exceeded Length")]
        public string PatientHistory { get; set; }
        public string AddressId { get; set; }
        [StringLength(500, ErrorMessage = "Full Address Exceeded Length")]
        public string FullAddress { get; set; }
        public string AppointmentId { get; set; }
        [DateValidation]
        public DateTime NextAppointmentDate { get; set; } = DateTime.Now.AddDays(-1);
        [Required(ErrorMessage ="Fees Required")]
        [Range(0, 100000, ErrorMessage = "Invalid Fees")]
        public double Fees { get; set; } = -1;
        public string DoctorId { get; set; }
        [Required(ErrorMessage ="Complain Required")]
        [StringLength(500, ErrorMessage = "Complain Exceeded Length")]
        public string Complain { get; set; }
        [Required(ErrorMessage = "RxTreatment Required")]
        [StringLength(500, ErrorMessage = "RxTreatment Exceeded Length")]
        public string RxTreatment { get; set; }
        [StringLength(500, ErrorMessage = "Diagnosis Exceeded Length")]
        public string Diagnosis { get; set; }
    }
}
