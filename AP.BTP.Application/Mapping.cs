using AP.BTP.Application.CQRS;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP.BTP.Domain;

namespace AP.BTP.Application
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<City, CityDTO>();
            CreateMap<Country, CountryDTO>();


        }
    }
}
