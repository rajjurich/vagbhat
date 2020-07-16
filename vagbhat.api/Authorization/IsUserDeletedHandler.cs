using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace vagbhat.api.Authorization
{
    public class IsUserDeletedHandler : AuthorizationHandler<IsUserDeletedRequirement>
    {
        private readonly UserManager<User> userManager;
       

        public IsUserDeletedHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;           
        }
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsUserDeletedRequirement requirement)
        {
            var a = context.Resource as AuthorizationFilterContext;

            var accessorId = context.User?.FindFirstValue("id");

            if (accessorId != null)
            {
                var accessor = await userManager.FindByIdAsync(accessorId);

                if (accessor.Deleted)
                {
                    context.Fail();
                }

                context.Succeed(requirement);
            }
        }
    }
}
