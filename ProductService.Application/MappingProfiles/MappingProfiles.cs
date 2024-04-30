using AutoMapper;
using ProductService.Application.Dtos;
using ProductService.Domain;

namespace ProductService.Application.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
