using System;
using System.Collections.Generic;
using System.Text;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Web.Models;

namespace Web.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public ApplicationDbContext(
            DbContextOptions options, 
            IOptions<OperationalStoreOptions> operationalStoreOptions
        ) : base(options, operationalStoreOptions)
        { }
        
        public DbSet<Car> Cars { get; set; } 
        public DbSet<CarBody> CarBodies { get; set; } 
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Equipment> Equipments { get; set; } 
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            base.OnModelCreating(builder);
        }
    }
}