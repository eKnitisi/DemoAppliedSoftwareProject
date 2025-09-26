using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<CountryDTO>>
    {
    }

    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllCountriesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CountryDTO>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries = uow.CountryRepository.GetAllCountries();
            return mapper.Map<IEnumerable<CountryDTO>>(countries);
        }
    }
}
