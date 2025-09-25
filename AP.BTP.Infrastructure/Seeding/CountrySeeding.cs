using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class CountrySeeding
    {
        public static void Seed(this EntityTypeBuilder<Country> modelBuilder)
        {

            modelBuilder.HasData(
                    new Country { Id = 1, Name = "Belgium" },
                    new Country { Id = 2, Name = "Netherlands" },
                    new Country { Id = 3, Name = "Germany" },
                    new Country { Id = 4, Name = "Turkey" }
                );
        }
    }
}
