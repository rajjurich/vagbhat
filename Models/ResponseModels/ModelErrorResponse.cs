using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ResponseModels
{
    public class ModelErrorResponse
    {
        public List<ModelError> ModelErrors { get; set; } = new List<ModelError>();
    }

    public class ModelError
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
