using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.CQRS
{
    public class UpdateCityCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
    }

    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, bool>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public UpdateCityCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var existingCity = await uow.CityRepository.GetCityById(request.Id);
            if (existingCity == null)
                return false;

            existingCity.Name = request.Name;
            existingCity.Population = request.Population;
            existingCity.CountryId = request.CountryId;

            await uow.CityRepository.UpdateCity(existingCity);
            await uow.Commit();

            return true;
        }
    }
}
