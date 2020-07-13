using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entities
{
    public class Role : IdentityRole
    {
        [Range(1, 20)]
        public int Rank { get; set; }
    }
}
