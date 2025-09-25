using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore;
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

        }
    }
}
