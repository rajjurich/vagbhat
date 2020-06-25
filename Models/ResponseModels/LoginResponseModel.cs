using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ResponseModels
{
    public class LoginResponseModel
    {
        public bool Success { get; set; }
        public string Token { get; set; }
        public string[] Errors { get; set; }
    }
}
