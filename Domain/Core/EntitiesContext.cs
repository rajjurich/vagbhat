using Domain.Extensions;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Core
{
    public class EntitiesContext : IdentityDbContext<User, Role, string>
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options)
            : base(options)
        {

        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Association> Associations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Seed();

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            FluentApis(builder);
        }

        private static void FluentApis(ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.AssociationId).HasMaxLength(450).IsRequired();
            builder.Entity<User>().Property(p => p.CreatorId).HasMaxLength(450).IsRequired();
            builder.Entity<User>().Property(p => p.Deleted).IsRequired();

            builder.Entity<Association>().HasKey(k => k.Id);
            builder.Entity<Association>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Association>().Property(p => p.AssociationName).HasMaxLength(450).IsRequired();          

            builder.Entity<RefreshToken>().HasKey(k => k.Token);
            builder.Entity<RefreshToken>().Property(p => p.Token).ValueGeneratedOnAdd();
            builder.Entity<RefreshToken>().Property(p => p.JwtId).HasMaxLength(450).IsRequired();                                       
        }
    }
}
