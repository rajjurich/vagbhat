using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Domain.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string userId = Guid.NewGuid().ToString();

            string roleId = Guid.NewGuid().ToString();

            string roleName = "sysadmin";

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = roleName,
                NormalizedName = roleName
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                UserName = roleName,
                NormalizedUserName = roleName,
                Email = "user@example.com",
                NormalizedEmail = "user@example.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "string"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(new IdentityUserClaim<string>
            {
                Id = 1,
                UserId = userId,
                ClaimType = ClaimTypes.Name,
                ClaimValue = "sysadmin"
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(new IdentityRoleClaim<string>
            {
                Id = 1,
                RoleId = roleId,
                ClaimType = ClaimTypes.Role,
                ClaimValue = roleName,
            });
        }
    }
}
