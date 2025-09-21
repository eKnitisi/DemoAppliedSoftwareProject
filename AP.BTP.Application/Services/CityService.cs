using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Services
{
    public class CityService : ICityService
    {
        private IUnitOfWork uow;
        public CityService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }
        public IEnumerable<City> GetAll()
        {
            return uow.CityRepository.GetAllCities();
        }
    }
}
