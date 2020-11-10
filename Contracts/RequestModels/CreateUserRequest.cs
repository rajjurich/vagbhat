using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.RequestModels
{
    public class CreateUserRequest
    {
        [EmailAddress(ErrorMessage = "Email format is invalid")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(250,ErrorMessage ="Exceeded Length")]
        public string Email { get; set; }
        [StringLength(250, ErrorMessage = "Exceeded Length")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password",ErrorMessage = "Password and Confirm Password does not match")]
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> RoleIds { get; set; }
    }
}
