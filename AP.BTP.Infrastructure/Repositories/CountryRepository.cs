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
    public class CountryRepository: GenericRepository<Country>,ICountryRepository
    {
        private BTPContext _BTPContext;
        public CountryRepository(BTPContext BTPContext):base(BTPContext)
        {
            this._BTPContext = BTPContext;
        }
        public IEnumerable<Country> GetAllCountries()
        {
            return _BTPContext.Countries;
        }

        
    }
}
