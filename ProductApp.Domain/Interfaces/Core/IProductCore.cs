using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Interfaces.Core
{
    public interface IProductCore
    {
        public ProductPagination Filter(ProductPagination pagination);
        Product Find(long id);
        long Add(Product item);
        bool Remove(long id);
        bool Edit(Product item);
    }
}
