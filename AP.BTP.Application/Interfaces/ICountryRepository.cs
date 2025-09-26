using AP.BTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Interfaces
{
    public interface ICountryRepository: IGenericRepository<Country>
    {
        public IEnumerable<Country> GetAllCountries();
        public Task<Country> FindByName(string name);
    }
}
