using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string TokenLifeTimeInMinutes { get; set; }
    }
}
