using Microsoft.EntityFrameworkCore;
using MicroStore.Data;
using MicroStore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroStore.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public T Find(int? id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).SingleOrDefault();
        }

        public IEnumerable<T> List()
        {
            return _context.Set<T>();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
