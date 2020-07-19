using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class TokenDto : ErrorDto
    {
        public string Access_Token { get; set; }
        public string Refresh_Token { get; set; }        
    }
}
