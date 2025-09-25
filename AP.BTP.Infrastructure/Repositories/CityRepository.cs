using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.Repositories
{
    public class CityRepository : ICityRepository
    {
        private BTPContext _BTPContext;
        public CityRepository(BTPContext BTPContext)
        {
            this._BTPContext = BTPContext;
        }
        public IEnumerable<City> GetAllCities()
        {
            return _BTPContext.Cities;
        }
        public IQueryable<City> GetAllCitiesQueryable() => _BTPContext.Cities.Include(c => c.Country).AsNoTracking();
        public Task<City?> GetByIdAsync(int id) =>
            _BTPContext.Cities.Include(c => c.Country).FirstOrDefaultAsync(c => c.Id == id);
        public Task<City?> GetByNameAsync(string name) =>
            _BTPContext.Cities.FirstOrDefaultAsync(c => c.Name == name);
        public void Update(City city)
        {
            _BTPContext.Cities.Update(city);
        }
    }
}
