using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public string AssociationId { get; set; }
        public virtual Association Association { get; set; }
    }
}
