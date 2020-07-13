using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class UserDto : ErrorDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }        
        public string PhoneNumber { get; set; }
        public string AssociationId { get; set; }
        public bool Deleted { get; set; }
    }
}
