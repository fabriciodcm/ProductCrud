using AutoMapper;
using ProductApp.Application.Interfaces.Services;
using ProductApp.Application.Models;
using ProductApp.Domain.Core;
using ProductApp.Domain.Interfaces.Core;
using ProductApp.Domain.Interfaces.Pagination;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;

namespace ProductApp.Application.Services
{
    public class ProductService : IProductService
    {
        
        private IMapper _mapper;
        private IProductCore _productCore;
        public ProductService(IProductCore productCore, IMapper mapper)
        {
            _productCore = productCore;
            _mapper = mapper;
        }
        public long Add(PostProductDTO item)
        {
            Product prd = _mapper.Map<Product>(item);
            return _productCore.Add(prd);
        }

        public bool Edit(PutProductDTO item)
        {
            var prd = _productCore.Find(item.Id);
            if (prd != null)
            {
                _mapper.Map(item, prd);
                return _productCore.Edit(prd);
            }
            return false;
        }

        public FilterProductDTO Filter(int take, int skip, string Description)
        {
            ProductPagination pagination = new ProductPagination()
            {
                skip = skip,
                take = take,
                Description = Description,
            };
            _productCore.Filter(pagination);
            var products = _mapper.Map<FilterProductDTO>(pagination);
            return products;
        }

        public ProductDTO Find(long id)
        {
            var prd = _productCore.Find(id);

            if (prd != null)
                return _mapper.Map<ProductDTO>(prd);

            return null;
        }

        public bool Remove(long id)
        {
            return _productCore.Remove(id);
        }
    }
}
