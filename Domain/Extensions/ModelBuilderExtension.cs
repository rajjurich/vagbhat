using Domain.Core;
using Domain.Entities;
using Domain.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class ModelBuilderExtension
    {
        //public static void Seed(this ModelBuilder modelBuilder)
        //{

        //}

        public static async Task SeedAsync(this EntitiesContext context
            , UserManager<User> userManager
            , RoleManager<Role> roleManager)
        {
            string userId = Guid.NewGuid().ToString();

            string roleId = Guid.NewGuid().ToString();

            string associationId = Guid.NewGuid().ToString();
            if (!await context.Associations.AnyAsync())
            {
                await context.AddAsync(new Association { Id = associationId, AssociationName = "self" });
                await context.SaveChangesAsync();
            }
            var roleName = AllowedRoles.Super;

            var role = new Role
            {
                Id = roleId,
                Name = roleName,
                AssociationId = associationId
            };

            //var roleAdmin = new Role
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = AllowedRoles.Admin
            //};

            //var roleSubadmin = new Role
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = AllowedRoles.Subadmin
            //};

            //var roleUser = new Role
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = AllowedRoles.User
            //};

            //var roleClient = new Role
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = AllowedRoles.Client
            //};

            if (!await context.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(role);
                //await roleManager.CreateAsync(roleAdmin);
                //await roleManager.CreateAsync(roleSubadmin);
                //await roleManager.CreateAsync(roleUser);
                //await roleManager.CreateAsync(roleClient);
            }

            var hasher = new PasswordHasher<User>();

            var user = new User
            {
                Id = userId,
                Email = "user@example.com",
                UserName = "user@example.com",
                PasswordHash = hasher.HashPassword(null, "string"),
                AssociationId = associationId,
                CreatorId = userId,
                Deleted = false
            };

            if (!await context.Users.AnyAsync())
            {
                await userManager.CreateAsync(user);
            }

            await userManager.AddToRoleAsync(user, roleName);

            List<Claim> userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName)
            };

            await userManager.AddClaimsAsync(user, userClaims);

            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, roleName));
            //await roleManager.AddClaimAsync(roleAdmin, new Claim(ClaimTypes.Role, AllowedRoles.Admin));
            //await roleManager.AddClaimAsync(roleSubadmin, new Claim(ClaimTypes.Role, AllowedRoles.Subadmin));
            //await roleManager.AddClaimAsync(roleUser, new Claim(ClaimTypes.Role, AllowedRoles.User));
            //await roleManager.AddClaimAsync(roleClient, new Claim(ClaimTypes.Role, AllowedRoles.Client));
        }
    }
}
