using AutoMapper;
using Core.Entities;
using ITIWEB.APIs.DTOs;

namespace ITIWEB.APIs.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureURL, o => o.MapFrom<pictureUrlResolver>());
        }
    }
}
