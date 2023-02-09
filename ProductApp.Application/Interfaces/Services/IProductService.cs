using Microsoft.AspNetCore.Mvc;
using ProductApp.Application.Models;
using ProductApp.Domain.Models.Pagination;
using System.Linq;

namespace ProductApp.Application.Interfaces.Services
{
    public interface IProductService
    {
        public ProductPagination Filter( int take,  int skip, string Description);
        ProductDTO Find(long id);
        void Add(PostProductDTO item);
        void Remove(long id);
        void Edit(PutProductDTO item);
    }
}
