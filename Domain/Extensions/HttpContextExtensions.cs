using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }

            //return httpContext.User.Claims.Single(x => x.Type == "id").Value;
            return httpContext.User?.FindFirstValue("id") ?? string.Empty;
        }

        public static string GetUserName(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User?.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value ?? string.Empty;
        }

        public static string GetEmail(this HttpContext httpContext)
        {
            if (httpContext.User == null)
            {
                return string.Empty;
            }

            return httpContext.User?.FindFirstValue(ClaimTypes.Email) ?? string.Empty;
        }
    }
}
