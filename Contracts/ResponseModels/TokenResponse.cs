using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class TokenResponse
    {
        public string Access_Token { get; set; }        
        public string Refresh_Token { get; set; }        
    }
}
