using AutoMapper;
using ProductApp.Application.Models;
using ProductApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud.UnitTests.Fixtures
{
    public class ProductFixtures
    {

        public static List<Product> GetTestProducts()  {
            List<Product> items = new List<Product>();
            for (int x = 1; x <= 50; x++) 
            {
                items.Add(new Product()
                {
                    Id= x,
                    Description = ("Produto " + x),
                    ValidateDate = DateTime.Now.AddYears(1),
                    FabricationDate = DateTime.Now,
                    SupplierId = x,
                    IsActive = true,
                    Supplier = new Supplier()
                    {
                        Description = ("Fornecedor " + x),
                        Id = x,
                        CNPJ = ("1231230001" + x),
                        IsActive= true
                    }
                });
            }
            return items;
        }

        public static PutProductDTO PutProductDTO()
        {
            Product prod = GetTestProducts().First();
            return new PutProductDTO()
            {
                Id = prod.Id,
                Description = prod.Description,
                ValidateDate = prod.ValidateDate,
                SupplierId = prod.SupplierId,
                FabricationDate = prod.FabricationDate
            };
        }
    }
}
