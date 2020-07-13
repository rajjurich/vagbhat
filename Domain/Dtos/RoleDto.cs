using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class RoleDto : ErrorDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}
