using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly IAssociationService associationService;

        public IsUserDeletedHandler(UserManager<User> userManager
            , IAssociationService associationService)
        {
            this.userManager = userManager;
            this.associationService = associationService;
        }
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsUserDeletedRequirement requirement)
        {
            var accessorId = context.User?.FindFirstValue("id");

            if (accessorId != null)
            {
                var accessor = await userManager.FindByIdAsync(accessorId);

                accessor.Association = await associationService.GetAsync(accessor.AssociationId);

                if (accessor.Deleted || accessor.Association.Deleted)
                {
                    context.Fail();
                }

                context.Succeed(requirement);
            }
        }
    }
}
