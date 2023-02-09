using AutoMapper;
using ProductApp.Application.Interfaces.Services;
using ProductApp.Application.Models;
using ProductApp.Domain.Interfaces.Pagination;
using ProductApp.Domain.Interfaces.Repository;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;

namespace ProductApp.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _uow;
        private IMapper _mapper;
        public ProductService(IProductRepository productRepository, IUnitOfWork uow, IMapper mapper)
        {
            _productRepository = productRepository;
            _uow = uow;
            _mapper = mapper;
        }
        public long Add(PostProductDTO item)
        {
            Product prd = _mapper.Map<Product>(item);
            _productRepository.Add(prd);
            _uow.Commit();
            return prd.Id;
        }

        public bool Edit(PutProductDTO item)
        {
            var prd = _productRepository.Find(item.Id);
            if (prd != null)
            {
                _mapper.Map(item, prd);
                _productRepository.Edit(prd);
                return _uow.Commit();
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
            _productRepository.Filter(pagination);
            var products = _mapper.Map<FilterProductDTO>(pagination);
            return products;
        }

        public ProductDTO Find(long id)
        {
            var prd = _productRepository.Find(id);

            if (prd != null)
                return _mapper.Map<ProductDTO>(prd);

            return null;
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
