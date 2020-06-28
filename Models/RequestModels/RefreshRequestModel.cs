using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.RequestModels
{
    public class RefreshRequestModel
    {
        [Required(ErrorMessage ="Token is required")]
        public string Token { get; set; }
        [Required(ErrorMessage = "Refresh token is required")]
        public string RefreshToken { get; set; }
    }
}
