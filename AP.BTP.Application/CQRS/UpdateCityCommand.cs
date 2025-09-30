using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
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
        public long Population { get; set; }
        public int CountryId { get; set; }
    }

    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        private IUnitOfWork uow;

        public UpdateCityCommandValidator(IUnitOfWork uow)
        {
            this.uow = uow;

            RuleFor(s => s.Name)
                .NotNull()
                .WithMessage("City cannot be empty")
                .MustAsync(async (command, name, cancellation) =>
                {
                    var city = await uow.CityRepository
                                        .FindAsync(c => c.Name.ToLower() == name.ToLower()
                                                     && c.Id != command.Id);
                    return city == null;
                })
                .WithMessage("The city is already added");

            RuleFor(s => s.Population)
                .LessThan(10000000000)
                .WithMessage("Too large of an population");

            RuleFor(s => s.CountryId)
                .NotNull()
                .WithMessage("Country cannot be empty");
        }
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
