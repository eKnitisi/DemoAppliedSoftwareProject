using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.CQRS
{
    public class AddCommand : IRequest<CityDTO>
    {
        public CityCreateDTO City { get; set; }
    }

    public class AddCommandHandler : IRequestHandler<AddCommand, CityDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<CityDTO> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            // Check if country already exists
            var country = await uow.CountryRepository
                .FindByName(request.City.CountryName); 

            if (country == null)
            {
                // Create new country
                country = new Country { Name = request.City.CountryName };
                await uow.CountryRepository.Create(country);
                await uow.Commit(); // get new country ID
            }

            // Create city and assign CountryId
            var cityEntity = mapper.Map<City>(request.City);
            cityEntity.CountryId = country.Id;

            await uow.CityRepository.Create(cityEntity);
            await uow.Commit();

            // Return the saved city
            return mapper.Map<CityDTO>(cityEntity);
        }
    }

}
