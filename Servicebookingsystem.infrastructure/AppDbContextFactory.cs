using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Servicebookingsystem.infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicebookingsystem.infrastructure
{

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=(local)\\SQLEXPRESS;Database=ServicePortal;User Id=sa;Password=Test@123;MultipleActiveResultSets=true;TrustServerCertificate=True"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
