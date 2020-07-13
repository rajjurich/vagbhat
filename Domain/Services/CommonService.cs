using Domain.Entities;
using Domain.Options;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICommonService
    {
        Task<bool> IsSuper(string id);
    }
    public class CommonService : ICommonService
    {
        private readonly UserManager<User> userManager;

        public CommonService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<bool> IsSuper(string id)
        {
            return await userManager.IsInRoleAsync(await userManager.FindByIdAsync(id), AllowedRoles.Super);
        }
    }
}
