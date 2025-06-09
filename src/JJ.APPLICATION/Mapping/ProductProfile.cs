using AutoMapper;
using JJ.APPLICATION.DTOs;
using JJ.DOMAIN.Entities;

namespace JJ.APPLICATION.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<CreateUpdateProductDTO, Product >();
        }
    }
}
