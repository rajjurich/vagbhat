using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Checks
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<HealthCheck> HealthChecks { get; set; }
    }
}
