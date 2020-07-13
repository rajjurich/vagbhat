using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.RequestModels
{
    public class UpdateRoleRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }
    }
}
