
using AutoMapper;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Products.Commands;

namespace CleanArchProject.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
            CreateMap<ProductDTO, ProductRemoveCommand>();
        }
    }
}
