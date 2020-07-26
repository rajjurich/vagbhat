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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }


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
            builder.Entity<User>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.CreatorId).HasMaxLength(450).IsRequired();
            builder.Entity<User>().Property(p => p.Deleted).IsRequired();
            builder.Entity<User>().Property(p => p.AddedDate).ValueGeneratedOnAdd().HasDefaultValueSql("GetDate()");
            builder.Entity<User>().Property(p => p.UpdatedDate).ValueGeneratedOnUpdate().HasDefaultValueSql("GetDate()");

            builder.Entity<Role>().Property(p => p.Rank).IsRequired();

            builder.Entity<RefreshToken>().HasKey(k => k.Token);
            builder.Entity<RefreshToken>().Property(p => p.Token).ValueGeneratedOnAdd();
            builder.Entity<RefreshToken>().Property(p => p.JwtId).HasMaxLength(450).IsRequired();

            builder.Entity<Address>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Address>().Property(p => p.PatientId).IsRequired();

            builder.Entity<Appointment>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(p => p.PatientId).IsRequired();
            builder.Entity<Appointment>().Property(p => p.DoctorId).IsRequired();

            builder.Entity<Doctor>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Doctor>().Property(p => p.UserId).IsRequired();
            builder.Entity<Doctor>().Property(p => p.DoctorName).IsRequired();
            builder.Entity<Doctor>().HasIndex(i => i.DoctorName);

            builder.Entity<Patient>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Patient>().Property(p => p.UserId).IsRequired();
            builder.Entity<Patient>().Property(p => p.PatientName).IsRequired();
            builder.Entity<Patient>().HasIndex(i => i.PatientName);
            builder.Entity<Patient>().Property(p => p.MobileNumber).HasMaxLength(15);
            builder.Entity<Patient>().Property(p => p.Gender).HasMaxLength(10);

            builder.Entity<Treatment>().HasOne(o => o.Appointment)
                .WithOne(o => o.Treatment)
                .HasForeignKey<Treatment>(fk => fk.Id);
        }
    }
}
