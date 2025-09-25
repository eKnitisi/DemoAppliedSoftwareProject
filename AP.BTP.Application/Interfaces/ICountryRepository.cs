using AP.BTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Interfaces
{
    public interface ICountryRepository
    {
        public IEnumerable<Country> GetAllCountries();
        IQueryable<Country> GetAllCountriesQueryable();
        Task<Country?> GetByIdAsync(int id);
    }
}
