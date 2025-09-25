using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.Contexts
{
    public class BTPContext : DbContext
    {
        public BTPContext(DbContextOptions<BTPContext> options) : base(options)
        { }
        public DbSet<City> Cities { get; set;}
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<City>().Seed();
            //modelBuilder.Entity<Country>().Seed();

            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Belgium" },
                new Country { Id = 2, Name = "Netherlands" },
                new Country { Id = 3, Name = "Germany" },
                new Country { Id = 4, Name = "Turkey"}
            );

            // Seed cities
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Brussels", Population = 1800000, CountryId = 1 },
                new City { Id = 2, Name = "Antwerp", Population = 529000, CountryId = 1 },
                new City { Id = 3, Name = "Amsterdam", Population = 872000, CountryId = 2 },
                new City { Id = 4, Name = "Rotterdam", Population = 651000, CountryId = 2 },
                new City { Id = 5, Name = "Berlin", Population = 3600000, CountryId = 3 }
            );
        }
    }
}
