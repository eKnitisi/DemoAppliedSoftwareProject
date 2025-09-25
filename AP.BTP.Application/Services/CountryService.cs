using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Services
{
    internal class CountryService: ICountryService
    {
        private IUnitOfWork uow;
        
        public CountryService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }
        public IEnumerable<City> GetAll()
        {
            return uow.CityRepository.GetAllCities();
        }
    }
}
