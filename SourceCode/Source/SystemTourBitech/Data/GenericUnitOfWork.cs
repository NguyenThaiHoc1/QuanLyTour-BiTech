using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Repository;

namespace Data
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private TourBitechContext _context = null;

        public GenericUnitOfWork()
        {
            _context = new TourBitechContext();
        }

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        // neu co thi co the la chinh khuc nay 
        public IRepository<T> Repository<T>() where T : class
        {
            IRepository<T> repo = null;
            if (repositories.ContainsKey(typeof(T)))
            {
                repo = repositories[typeof(T)] as IRepository<T>;
            }
            else
            {
                repo = new GenericRepository<T>(_context);
                repositories.Add(typeof(T), repo);
            }
            return repo;
        }

        public int SaveChange()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
