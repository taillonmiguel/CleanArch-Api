using AutoMapper;
using CleanArch.AppService.DTOs;
using CleanArch.Dominio.Entities;

namespace CleanArch.AppService.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
