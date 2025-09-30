using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext _BTPContext;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public UnitOfWork(BTPContext BTPContext, ICityRepository cityRepository, ICountryRepository countryRepository) 
        {
            this._BTPContext = BTPContext;
            this._cityRepository = cityRepository;
            this._countryRepository = countryRepository;
        }
        public ICityRepository CityRepository => _cityRepository;

        public ICountryRepository CountryRepository => _countryRepository;

        public async Task Commit()
        {
            await _BTPContext.SaveChangesAsync();
        }
    }
}
