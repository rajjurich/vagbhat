using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Appointment
    {
        public string AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public bool IsVisited { get; set; }
        public double Fees { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Treatment Treatment { get; set; }
    }
}
