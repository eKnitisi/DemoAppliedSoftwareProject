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
    public class GetAllCitiesQuery : IRequest<IEnumerable<CityDTO>>
    {
        public bool SortDesc { get; set; }
        public GetAllCitiesQuery(bool sortDesc = false) => SortDesc = sortDesc;

    }

    public class GetAllCitiesQueryHandler : IRequestHandler<GetAllCitiesQuery, IEnumerable<CityDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllCitiesQueryHandler(IUnitOfWork uow, IMapper mapper) 
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CityDTO>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            var cities = await uow.CityRepository.GetAllCities();

            if (request.SortDesc)
                cities = cities.OrderByDescending(c => c.Population).ToList();
            else
                cities = cities.OrderBy(c => c.Population).ToList();

            return mapper.Map<IEnumerable<CityDTO>>(cities);
        }
    }
}
