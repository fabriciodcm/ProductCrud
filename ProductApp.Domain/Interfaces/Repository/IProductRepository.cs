using ProductApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public List<Product> Filter(string Description, DateTime? FabricationDate, DateTime? ValidateDate);
    }
}
