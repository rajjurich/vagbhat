using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class TreatmentResponse
    {
        public string Id { get; set; }
        public string Complain { get; set; }
        public string RxTreatment { get; set; }
        public string Diagnosis { get; set; }
    }
}
