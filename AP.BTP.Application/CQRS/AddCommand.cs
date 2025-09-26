using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
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
    public class AddCommand : IRequest<CityDTO>
    {
        public CityCreateDTO City { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        private IUnitOfWork uow;

        public AddCommandValidator(IUnitOfWork uow)
        {
            this.uow = uow;

            RuleFor(s => s.City.Name)
    .NotNull()
    .WithMessage("City cannot be empty")
    .MustAsync(async (name, cancellation) =>
    {
        var city = await uow.CityRepository
                            .FindAsync(c => c.Name.ToLower() == name.ToLower());
        return city == null; 
    })
    .WithMessage("The city is already added");


            RuleFor(s => s.City.Population)
                .LessThan(10000000000)
                .WithMessage("Too large of an population");

            RuleFor(s => s.City.CountryName)
                .NotNull()
                .WithMessage("Country cannot be empty");
        }
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
            var country = await uow.CountryRepository
    .FindAsync(c => c.Name.ToLower() == request.City.CountryName.ToLower());


            if (country == null)
            {
                country = new Country { Name = request.City.CountryName };
                await uow.CountryRepository.Create(country);
                await uow.Commit(); 
            }

            var cityEntity = mapper.Map<City>(request.City);
            cityEntity.CountryId = country.Id;

            await uow.CityRepository.Create(cityEntity);
            await uow.Commit();

            return mapper.Map<CityDTO>(cityEntity);
        }
    }

}
