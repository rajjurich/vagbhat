using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Doctor
    {
        public string Id { get; set; }
        public string DoctorName { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
