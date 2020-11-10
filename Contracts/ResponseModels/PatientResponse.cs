using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class PatientResponse
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public string MobileNumber { get; set; }
    }
}
