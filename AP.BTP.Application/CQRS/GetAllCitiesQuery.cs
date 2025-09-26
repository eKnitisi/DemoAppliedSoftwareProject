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
            return mapper.Map<IEnumerable<CityDTO>>(await uow.CityRepository.GetAllCities());
        }
    }
}
