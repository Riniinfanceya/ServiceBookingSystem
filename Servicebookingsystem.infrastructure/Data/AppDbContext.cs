using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Servicebookingsystem.core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Admin> Admins { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.IsActive = true;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    // Soft delete
                    entry.State = EntityState.Modified;
                    entry.Entity.IsActive = false;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}
