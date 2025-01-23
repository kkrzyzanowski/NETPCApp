using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NETPCApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NETPCApp.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=NETPCAppDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }

            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                Email = "test@test.pl",
                PasswordHash = "$2a$12$9f9vOPF/V.i7HJXC9PIya.bJlJNMZW6LNPgc08.ZIuqZ5WjrW0TmG",
                FirstName = "test",
                LastName = "test",
                BirthDate = DateTime.Now,
                Category = "Other",
                PhoneNumber = "1234567890",
                Subcategory = ""
            });
        }
    }
}
