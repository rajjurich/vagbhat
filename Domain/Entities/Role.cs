using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        public string AssociationId { get; set; }
        public bool Deleted { get; set; }
        [Range(1, 100)]
        public int Rank { get; set; }
        public virtual Association Association { get; set; }
    }
}
