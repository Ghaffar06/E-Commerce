using AppDbContext.Models;
using AutoMapper;
using ECommerce.Models;

namespace ECommerce.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryVM>()
                .ForMember(c => c.Attributes, opt => opt.MapFrom(c => c.CategoryAttribute))
                .ReverseMap();
             CreateMap<Product, ProductVM>()
                .ReverseMap();


            CreateMap<CategoryAttribute, AttributeVM>()
                .ForMember(cvm => cvm.Required, opt => opt.MapFrom(c => c.Required == "F"))
                .ForMember(cvm => cvm.ValueType, opt => opt.MapFrom(c => c.Attribute.ValueType))
                .ForMember(cvm => cvm.Description, opt => opt.MapFrom(c => c.Attribute.Description))
                .ForMember(cvm => cvm.Name, opt => opt.MapFrom(c => c.Attribute.Name))
                .ForMember(cvm => cvm.Id, opt => opt.MapFrom(c => c.Id));

            CreateMap<AttributeVM, Attribute>()
                .ForMember(attr => attr.Name, opt => opt.MapFrom(vm => vm.Name))
                .ForMember(attr => attr.Description, opt => opt.MapFrom(vm => vm.Description));

            CreateMap<ValueType, ValueTypeVM>()
                .ReverseMap();
        }
    }
}
