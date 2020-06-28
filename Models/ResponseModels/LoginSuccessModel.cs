using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ResponseModels
{
    public class LoginSuccessModel
    {
        public string Token { get; set; }        
        public string RefreshToken { get; set; }
    }
}
