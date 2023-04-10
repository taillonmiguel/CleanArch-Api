using AutoMapper;
using CleanArch.AppService.DTOs;
using CleanArch.AppService.Products.Commands;

namespace CleanArch.AppService.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
