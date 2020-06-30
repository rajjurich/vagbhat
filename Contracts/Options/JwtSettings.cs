using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Options
{
    public class JwtSettings
    {
        public string Secret { get; set; }
        public string TokenLifeTimeInMinutes { get; set; }
    }
}
