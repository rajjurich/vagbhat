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
            var unitOfWork = context.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var x = context.HttpContext.Request.Method;

            await unitOfWork.BeginTransactionAsync();

            var result = await next();
            
            if (!(x.Equals("get", StringComparison.OrdinalIgnoreCase)))
            {
                
                if (result.Exception == null)
                {
                    // commit if no exceptions                
                    await unitOfWork.CommitTransactionAsync();
                }
                else
                {
                    // rollback if exception
                    await unitOfWork.RollbackTransactionAsync();
                }
            }
        }
    }
}
