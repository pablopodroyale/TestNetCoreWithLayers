using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using TestNetCore.Core.Model;
using TestNetCore.Dal.Configuration;

namespace TestNetCore.Dal
{
    public class TestNetCoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Logs> Logs { get; set; }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Phone> Phones { get; set; }


        public TestNetCoreDbContext(DbContextOptions<TestNetCoreDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();

        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);

        //    builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
        //}
    }
}
