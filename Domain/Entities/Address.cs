using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Address
    {
        public string Id { get; set; }
        public string FullAddress { get; set; }
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
