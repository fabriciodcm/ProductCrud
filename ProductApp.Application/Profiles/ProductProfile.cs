using AutoMapper;
using ProductApp.Application.Models;
using ProductApp.Domain.Models;
using ProductApp.Domain.Models.Pagination;
using System.Linq;

namespace ProductApp.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<SupplierDTO, Supplier>()
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => true));
            CreateMap<Supplier, SupplierDTO>();
            CreateMap<Product, ProductDTO>().ForMember(d => d.Supplier,
                    opt => {
                        opt.PreCondition(src => (src.Supplier != null));
                        opt.MapFrom(src => src.Supplier); ;
                    }
                );
            CreateMap<PostProductDTO, Product>()
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => true))
                .ForMember(d => d.Supplier,
                    opt => {
                        opt.PreCondition(src => (src.Supplier != null));
                        opt.MapFrom(src => src.Supplier); ;
                    }
                ); 
            
            CreateMap<PutProductDTO, Product>()
                .ForMember(d => d.IsActive, opt => opt.MapFrom(src => true));
            CreateMap<Product, PutProductDTO>();

            CreateMap<ProductPagination, FilterProductDTO>().ForMember(d => d.rows,
                    opt =>
                    {
                        opt.PreCondition(src => (src.rows != null));
                        opt.MapFrom(src => src.rows); ;
                    }
                );
        }
    }
}
