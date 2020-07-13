using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.RequestModels
{
    public class CreateRoleRequest
    {
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }        
    }
}
