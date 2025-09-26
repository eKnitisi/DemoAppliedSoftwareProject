using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS
{
    internal class GetCityByIdQuery : IRequest<CityDTO?>
    {
        public int Id { get; set; }

        public GetCityByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetCityByIdQueryHandler : IRequestHandler<GetCityByIdQuery, CityDTO?>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetCityByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<CityDTO?> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await uow.CityRepository.GetCityById(request.Id);
            return mapper.Map<CityDTO>(city);
        }
    }
}
