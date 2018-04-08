using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using STDAL.Configuration;
using STDAL.Entities;

namespace STDAL.EF
{
    public partial class STDBContext : DbContext
    {
        public virtual DbSet<EmployeeGroup> EmployeeGroup { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<SubmissionRelations> SubmissionRelations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appsettings.json");

                var config = builder.Build();
                string connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseSqlite(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeGroupConfiguration());
            modelBuilder.ApplyConfiguration(new StaffConfiguration());
            modelBuilder.ApplyConfiguration(new SubmissionRelationsConfiguration());
        }
    }
}
