using ProductApp.Domain.Interfaces.Pagination;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public ProductPagination Filter(ProductPagination query);
    }
}
