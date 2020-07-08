using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.Extensions
{
    public static class GenericTypeExtensions
    {        
        public static string GetGenericTypeName(this object obj)
        {
            return obj.GetType().ToString();
        }
    }
}
