using Microsoft.EntityFrameworkCore;
using ProductApp.Data.Context;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseData
    {
        private DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }
        
        public void Add(T item)
        {
             _context.Set<T>().Add(item);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Edit(T item)
        {
            _context.Attach<T>(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public T Find(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> List()
        {
            return _context.Set<T>();
        }

        public void Remove(T item)
        {
            item.IsActive = false;
            _context.Attach<T>(item);
            _context.Entry(item).State = EntityState.Modified;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
