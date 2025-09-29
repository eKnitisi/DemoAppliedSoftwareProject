using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AP.BTP.Application.CQRS;


namespace AP.BTP.Infrastructure.Repositories
{
    public class CityRepository :  GenericRepository<City>,ICityRepository
    {
        private readonly DbContext _BTPContext;
        private readonly DbSet<City> _dbSet;
        public CityRepository(BTPContext BTPContext): base(BTPContext)
        {
            this._BTPContext = BTPContext;
            _dbSet = _BTPContext.Set<City>();

        }
        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<City> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
