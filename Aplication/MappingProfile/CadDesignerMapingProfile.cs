using AutoMapper;
using CadDesigner.Aplication.DtoModels;
using CadDesigner.Domain.Entitys;


namespace CadDesigner.Aplication.MappingProfile
{
    public class CadDesignerMapingProfile : Profile
    {
        public CadDesignerMapingProfile()
        {
            CreateMap<Designer, DesignerDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<Service, ServiceDto>();

            CreateMap<CreateDesignertDto, Designer>();
               

            CreateMap<CreateServiceDto, Service>();
        }
    }
}