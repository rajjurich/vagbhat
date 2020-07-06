using Domain.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vagbhat.api.Filters
{
    public class UnitOfWorkAsyncActionFilters : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();
            var x = context.HttpContext.Request.Method;
            if (!(x.Equals("get", StringComparison.OrdinalIgnoreCase)))
            {
                var unitOfwork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
                if (result.Exception == null)
                {
                    // commit if no exceptions                
                    await unitOfwork.Commit();
                }
                else
                {
                    // rollback if exception
                    await unitOfwork.Rollback();
                }
            }
        }
    }
}
