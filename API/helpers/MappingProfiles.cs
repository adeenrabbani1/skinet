using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>().ForMember(p => p.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(p => p.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(p => p.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

        }
    }
}