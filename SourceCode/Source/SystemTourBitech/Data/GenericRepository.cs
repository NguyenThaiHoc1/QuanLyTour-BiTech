using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Core.Repository;

namespace Data
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private TourBitechContext _context;
        public GenericRepository(TourBitechContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().First(predicate);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>().Where(predicate);
            }
            return _context.Set<T>().AsEnumerable<T>();
        }
    }
}
