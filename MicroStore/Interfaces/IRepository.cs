using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroStore.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List();
        T Find(int? id);
        T Find(Func<T, bool> predicate);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
