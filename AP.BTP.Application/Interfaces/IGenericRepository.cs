using AP.BTP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll(int pageNr, int pageSize);

        Task<T> GetById(int id);
        Task<T> Create(T newCity);

        T Update(T modifiedCity);
        void Delete(T city); 
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
    }
}
