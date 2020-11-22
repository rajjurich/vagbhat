using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class PatientResponse
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string PatientHistory { get; set; }
        public string AddressId { get; set; }
        public string FullAddress { get; set; }
        public string AppointmentId { get; set; }
    }
}
