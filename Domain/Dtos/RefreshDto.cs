using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos
{
    public class RefreshDto
    {        
        public string Access_Token { get; set; }
     
        public string Refresh_Token { get; set; }
    }
}
