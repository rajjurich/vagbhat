﻿using Domain.Core;
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
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //string userId = Guid.NewGuid().ToString();

            //string roleId = Guid.NewGuid().ToString();

            //string roleName = "sysadmin";

            //modelBuilder.Entity<Role>().HasData(new Role
            //{
            //    Id = roleId,
            //    Name = roleName,
            //    NormalizedName = roleName
            //});

            //var hasher = new PasswordHasher<User>();
            //modelBuilder.Entity<User>().HasData(new User
            //{
            //    Id = userId,
            //    UserName = roleName,
            //    NormalizedUserName = roleName,
            //    Email = "user@example.com",
            //    NormalizedEmail = "user@example.com",
            //    EmailConfirmed = true,
            //    PasswordHash = hasher.HashPassword(null, "string"),
            //    SecurityStamp = Guid.NewGuid().ToString()
            //});

            //modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = roleId,
            //    UserId = userId
            //});

            //modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            //{
            //    Id = 1,
            //    UserId = userId,
            //    ClaimType = ClaimTypes.Name,
            //    ClaimValue = "sysadmin"
            //});

            //modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(new IdentityRoleClaim<string>
            //{
            //    Id = 1,
            //    RoleId = roleId,
            //    ClaimType = ClaimTypes.Role,
            //    ClaimValue = roleName,
            //});
        }

        public static async Task SeedAsync(this EntitiesContext context
            , UserManager<User> userManager
            , RoleManager<Role> roleManager)
        {
            string userId = Guid.NewGuid().ToString();

            string roleId = Guid.NewGuid().ToString();

            string associationId = Guid.NewGuid().ToString();

            var roleName = AllowedRoles.Super;

            var role = new Role
            {
                Id = roleId,
                Name = roleName
            };

            if (!await context.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(role);
                await roleManager.CreateAsync(new Role { Name = AllowedRoles.Admin });
                await roleManager.CreateAsync(new Role { Name = AllowedRoles.User });
                await roleManager.CreateAsync(new Role { Name = AllowedRoles.Client });
            }

            await context.AddAsync(new Association { Id = associationId, AssociationName = "self" });
            await context.SaveChangesAsync();

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

            List<Claim> userClaims = new List<Claim>();
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));

            await userManager.AddClaimsAsync(user, userClaims);

            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, roleName));
            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, AllowedRoles.Admin));
            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, AllowedRoles.User));
            await roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, AllowedRoles.Client));
        }
    }
}
