using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Checks
{
    public class HealthCheckResponse
    {
        public string Status { get; set; }
        public TimeSpan Duration { get; set; }
        public IEnumerable<HealthCheck> HealthChecks { get; set; }
    }
}
