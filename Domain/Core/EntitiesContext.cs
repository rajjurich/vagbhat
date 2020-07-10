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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Seed();

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            FluentApis(builder);
        }

        private static void FluentApis(ModelBuilder builder)
        {
            builder.Entity<Association>().HasKey(k => k.Id);
            builder.Entity<Association>().HasMany(m => m.User)
                .WithOne(o=>o.Association)
                .HasForeignKey(fk=>fk.AssociationId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RefreshToken>().HasKey(k => k.Token);
            builder.Entity<RefreshToken>().Property(p => p.Token).ValueGeneratedOnAdd();
            builder.Entity<RefreshToken>().Property(p => p.JwtId).HasMaxLength(450).IsRequired();            
            builder.Entity<RefreshToken>()
                            .HasOne(o => o.User)
                            .WithMany(m => m.RefreshTokens)
                            .IsRequired()
                            .HasForeignKey(fk => fk.UserId)
                            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
