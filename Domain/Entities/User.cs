using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string AssociationId { get; set; }
        public Association Association { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
