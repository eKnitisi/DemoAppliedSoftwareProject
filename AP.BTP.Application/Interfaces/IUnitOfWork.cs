using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public ICityRepository CityRepository {get;}
        Task Commit();
    }
}
