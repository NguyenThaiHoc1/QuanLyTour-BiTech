using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    
    public interface IUnitOfWork : IDisposable
    {
        
        IRepository<T> Repository<T>() where T : class;
        int SaveChange();
        void Dispose(bool disposing);
        new void Dispose();
    }
}
