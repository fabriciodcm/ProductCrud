using ProductApp.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApp.Domain.Interfaces.Repository
{
    public interface IRepository<T> : IDisposable where T : BaseData
    {
        T Find(long id);
        IQueryable<T> List();
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
        int SaveChanges();
    }
}
