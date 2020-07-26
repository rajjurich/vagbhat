using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Patient
    {
        public string Id { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public string PatientHistory { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
