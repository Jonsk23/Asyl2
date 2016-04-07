using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class AzureDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<JobAd> JobAd { get; set; }
        public DbSet<Talent> Talents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<JobAd>().ToTable("JobAd");
            modelBuilder.Entity<Talent>().ToTable("Talents");
            modelBuilder.Entity<Location>().ToTable("Location");
        }
    }
}
