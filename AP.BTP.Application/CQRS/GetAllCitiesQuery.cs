using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AP.BTP.Application.Interfaces;
namespace AP.BTP.Application.CQRS
{
    public class GetAllCitiesQuery : IRequest<IEnumerable<CityDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }

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
            return mapper.Map<IEnumerable<CityDTO>>(uow.CityRepository.GetAllCities());
        }
    }
}
