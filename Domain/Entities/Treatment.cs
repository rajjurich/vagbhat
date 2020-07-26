using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Treatment
    {
        public string Id { get; set; }
        public string Complain { get; set; }
        public string RxTreatment { get; set; }
        public string Diagnosis { get; set; }
        public virtual Appointment Appointment { get; set; }
    }
}
