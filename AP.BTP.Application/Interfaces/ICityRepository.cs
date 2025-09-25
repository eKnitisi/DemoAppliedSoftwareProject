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
        public IEnumerable<City> GetAllCities();
        IQueryable<City> GetAllCitiesQueryable(); // return IQueryable for Include/OrderBy
        Task<City?> GetByIdAsync(int id);
        Task<City?> GetByNameAsync(string name);
        void Update(City city);
    }
}
