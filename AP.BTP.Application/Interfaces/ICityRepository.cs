using AP.BTP.Application.CQRS;
using AP.BTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Interfaces
{
    public interface ICityRepository
    {
        public Task<IEnumerable<City>> GetAllCities();
        public Task<City?> GetCityById(int id);
        public Task UpdateCity(City city);
    }
}
