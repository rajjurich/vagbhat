using Contracts.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace vagbhat.api.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment env;

        public ApiExceptionFilter(IHostEnvironment env)
        {
            this.env = env;
        }
        public void OnException(ExceptionContext context)
        {
            var json = new ErrorResponse
            {
                Errors = new[] { "An error occured. Try it again." }
            };

            if (env.IsDevelopment())
            {
                json.Description = context.Exception.ToString();
            }

            context.Result = new ObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
