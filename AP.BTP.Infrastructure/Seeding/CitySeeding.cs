using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class CitySeeding
    {
        public static void Seed(this EntityTypeBuilder<City> modelBuilder)
        {
            modelBuilder.HasData(
                new City { Id = 1, Name = "Brussels", Population = 1800000, CountryId = 1 },
                new City { Id = 2, Name = "Antwerp", Population = 529000, CountryId = 1 },
                new City { Id = 3, Name = "Amsterdam", Population = 872000, CountryId = 2 },
                new City { Id = 4, Name = "Rotterdam", Population = 651000, CountryId = 2 },
                new City { Id = 5, Name = "Berlin", Population = 3600000, CountryId = 3 }
            );
        }


    }
}
