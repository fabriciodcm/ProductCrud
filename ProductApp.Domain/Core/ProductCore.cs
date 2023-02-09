using ProductApp.Domain.Interfaces.Core;
using ProductApp.Domain.Interfaces.Pagination;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Domain.Core
{
    public class ProductCore : IProductCore
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _uow;

        public ProductCore(IProductRepository productRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }

        public long Add(Product item)
        {
            _productRepository.Add(item);
            _uow.Commit();
            return item.Id;
        }

        public bool Edit(Product item)
        {
            _productRepository.Edit(item);
            return _uow.Commit();
        }

        public ProductPagination Filter(ProductPagination pagination)
        {
            return _productRepository.Filter(pagination);
        }

        public Product Find(long id)
        {
            return _productRepository.Find(id);
        }

        public bool Remove(long id)
        {
            var prd = _productRepository.Find(id);
            if (prd != null)
            {
                _productRepository.Remove(prd);
                return _uow.Commit();
            }
            return false;
        }
    }
}
