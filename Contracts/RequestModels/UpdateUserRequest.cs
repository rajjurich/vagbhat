using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.RequestModels
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "Id is required")]
        public string Id { get; set; }
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
