using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Association
    {
        public string Id { get; set; }
        public string AssociationName { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
