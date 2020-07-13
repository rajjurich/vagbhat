using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public bool Deleted { get; set; }
        public string CreatorId { get; set; }
        public string AssociationId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual User Creator { get; set; }
        public virtual Association Association { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
