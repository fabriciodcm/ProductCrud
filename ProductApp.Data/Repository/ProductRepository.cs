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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
        }

        public List<Product> Filter(string Description, DateTime? FabricationDate, DateTime? ValidateDate)
        {
            IQueryable<Product> products = List().Include(x => x.Supplier);

            if (!string.IsNullOrEmpty(Description))
                products = products.Where(x => x.Description == Description);
            if (FabricationDate.HasValue)
                products = products.Where(x => x.FabricationDate.Date == FabricationDate.Value.Date);
            if (ValidateDate.HasValue)
                products = products.Where(x => x.ValidateDate.Date == ValidateDate.Value.Date);

            return products.AsNoTracking().ToList();
        }
    }
}
