using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public List<RoleResponse> Roles { get; set; }
    }
}
