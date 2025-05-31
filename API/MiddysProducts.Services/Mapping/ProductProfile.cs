using AutoMapper;
using MiddysProducts.Data.Models;
using MiddysProducts.Services.Models;

namespace MiddysProducts.Services.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
        }
    }
}
