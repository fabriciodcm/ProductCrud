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
        public ProductService(IProductRepository productRepository, IUnitOfWork uow)
        {
            _productRepository = productRepository;
            _uow = uow;
        }
        public long Add(PostProductDTO item)
        {
            var prd = new Product()
            {
                Description = item.Description,
                SupplierId = item.SupplierId,
                ValidateDate = item.ValidateDate,
                FabricationDate = item.FabricationDate,
                IsActive = true
            };
            if (item.Supplier != null)
            {
                prd.Supplier = new Supplier()
                {
                    Description = item.Supplier.Description,
                    CNPJ = item.Supplier.CNPJ,
                    IsActive = true
                };
            }
            _productRepository.Add(prd);
            _uow.Commit();
            return prd.Id;
        }

        public bool Edit(PutProductDTO item)
        {
            var prd = _productRepository.Find(item.Id);
            if (prd != null)
            {
                prd.Description = item.Description;
                prd.SupplierId = item.SupplierId;
                prd.ValidateDate = item.ValidateDate;
                prd.FabricationDate = item.FabricationDate;
                _productRepository.Edit(prd);
                return _uow.Commit();
            }
            return false;
        }

        public ProductPagination Filter(int take, int skip, string Description)
        {
            ProductPagination pagination = new ProductPagination()
            {
                skip = skip,
                take = take,
                Description = Description,
            };
            return _productRepository.Filter(pagination);
        }

        public ProductDTO Find(long id)
        {
            var prd = _productRepository.Find(id);

            if (prd != null)
                return new ProductDTO()
                {
                    Id = prd.Id,
                    Description = prd.Description,
                    ValidateDate = prd.ValidateDate,
                    FabricationDate = prd.FabricationDate,
                    SupplierId = prd.SupplierId,
                };

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
