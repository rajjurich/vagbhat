﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Checks
{
    public class HealthCheck
    {
        public string Status { get; set; }
        public string Component { get; set; }
        public string Description { get; set; }
    }
}
