using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class RoleResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}
