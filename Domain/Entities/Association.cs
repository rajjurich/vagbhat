using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Association
    {
        public string Id { get; set; }
        public string AssociationName { get; set; }        
        public ICollection<User> User { get; set; }
    }
}
