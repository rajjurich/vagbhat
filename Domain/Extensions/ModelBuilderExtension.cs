using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            string userId = Guid.NewGuid().ToString();

            string roleId = Guid.NewGuid().ToString();

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = roleId,
                Name = "sysadmin",
                NormalizedName = "sysadmin"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = userId,
                UserName = "sysadmin",
                NormalizedUserName = "sysadmin",
                Email = "rajju2512@gmail.com",
                NormalizedEmail = "rajju2512@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "sysadmin@123"),
                SecurityStamp = Guid.NewGuid().ToString()
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }
    }
}
