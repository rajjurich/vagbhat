using Contracts.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.Extensions
{
    public static class GenericTypeExtensions
    {
        public static ErrorResponse Error(this object obj, string[] errors)
        {
            return new ErrorResponse
            {
                Description = obj.GetGenericTypeName(),
                Errors = errors
            };
        }
    }
}
