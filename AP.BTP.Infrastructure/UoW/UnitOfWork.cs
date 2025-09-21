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
        private BTPContext _BTPContext;
        private ICityRepository _cityRepository;

        public UnitOfWork(BTPContext BTPContext, ICityRepository cityRepository) 
        {
            this._BTPContext = BTPContext;
            this._cityRepository = cityRepository;
        }
        public ICityRepository CityRepository => _cityRepository;

        public async Task Commit()
        {
            await _BTPContext.SaveChangesAsync();
        }
    }
}
