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
        private readonly DbSet<City> _dbSet;
        public CityRepository(BTPContext BTPContext)
        {
            this._BTPContext = BTPContext;
            _dbSet = _BTPContext.Set<City>();
        }
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _dbSet.Include(c => c.Country).ToListAsync();
        }

        public async Task<City?> GetCityById(int id)
        {
            return await _dbSet.Include(c => c.Country)
                              .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCity(City city)
        {
            _BTPContext.Entry(city).State = EntityState.Modified;
        }
    }
}
