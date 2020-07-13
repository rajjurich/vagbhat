using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class AssociationDto
    {
        public string Id { get; set; }
        public string AssociationName { get; set; }
        public bool Deleted { get; set; }
    }
}
