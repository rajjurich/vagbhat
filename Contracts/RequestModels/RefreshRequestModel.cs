using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contracts.RequestModels
{
    public class RefreshRequestModel
    {
        [Required(ErrorMessage ="Access Token is required")]
        public string Access_Token { get; set; }
        [Required(ErrorMessage = "Refresh token is required")]
        public string Refresh_Token { get; set; }
    }
}
