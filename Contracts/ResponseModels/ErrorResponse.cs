using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ResponseModels
{
    public class ErrorResponse
    {
        public string Description { get; set; }
        public string[] Errors { get; set; }
    }
}
