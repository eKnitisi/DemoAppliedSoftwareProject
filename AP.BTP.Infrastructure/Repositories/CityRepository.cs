using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;
using AP.BTP.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.Repositories
{
    public class CityRepository :  GenericRepository<City>,ICityRepository
    {
        private BTPContext _BTPContext;
        public CityRepository(BTPContext BTPContext):base(BTPContext)
        {
            this._BTPContext = BTPContext;
        }
        public IEnumerable<City> GetAllCities()
        {
            return _BTPContext.Cities;
        }
    }
}
