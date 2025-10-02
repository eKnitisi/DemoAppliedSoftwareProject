using AP.BTP.Application.CQRS;
using AP.BTP.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CityCreateDTO, City>();

            CreateMap<City, CityDTO>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

            CreateMap<Country, CountryDTO>();

        }
    }

}

