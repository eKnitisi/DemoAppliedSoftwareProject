using AP.BTP.Application.Exceptions;
using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS
{
    public class RemoveCommand() : IRequest<CityDTO>
    {
        public int Id { get; set; }
    }
    
    public class RemoveCommandValidator : AbstractValidator<RemoveCommand>
    {
        public RemoveCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
    
    public class RemoveCommandHandler : IRequestHandler<RemoveCommand, CityDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;

        public RemoveCommandHandler(IUnitOfWork uow, IMapper mapper, IEmailService emailService)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.emailService = emailService;
        }

        public async Task<CityDTO> Handle(RemoveCommand request, CancellationToken cancellationToken)
        {
            var city = await uow.CityRepository.GetByIdAsync(request.Id);
            if (city == null)
                return null;
            
            // De laatste stad in de databank kan niet verwijderd worden
            var allCities = await uow.CityRepository.GetAllCities();
            if (allCities.Count() <= 1)
            {
                throw new LastCityDeletionNotAllowedException();
            }

            uow.CityRepository.Delete(city);
            await uow.Commit();

            // Simuleer het versturen van een e-mail naar de admin
            var adminEmail = "admin@ap.be";
            var subject = "City Deleted Notification";
            var body = $"The city '{city.Name}' has been removed from the database.";
            await emailService.SendEmailAsync(adminEmail, subject, body);
            
            return mapper.Map<CityDTO>(city);
        }
    }
}