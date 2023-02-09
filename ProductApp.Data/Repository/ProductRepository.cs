using Microsoft.EntityFrameworkCore;
using ProductApp.Data.Context;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;
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

        public ProductPagination Filter(ProductPagination pagination)
        {


            IQueryable<Product> products = List().Include(x => x.Supplier).Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(pagination.Description))
                products = products.Where(x => x.Description.Contains(pagination.Description));
            if (pagination.FabricationDate.HasValue)
                products = products.Where(x => x.FabricationDate.Value.Date == pagination.FabricationDate.Value.Date);
            if (pagination.ValidateDate.HasValue)
                products = products.Where(x => x.ValidateDate.Value.Date == pagination.ValidateDate.Value.Date);

            pagination.count = products.Count();

            pagination.rows = products.AsNoTracking()
                .Skip(pagination.skip)
                .Take(pagination.take)
                .OrderBy(x => x.Id)
                .ToList();

            return pagination;
        }
    }
}
