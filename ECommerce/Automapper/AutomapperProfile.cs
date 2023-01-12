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
               .ForMember(pvm => pvm.PriceIsInteger, opt => opt.MapFrom(p => p.PriceIsInteger == "T"))
               .ForMember(pvm => pvm.Categories, opt => opt.MapFrom(p => p.CategoryProduct));

            CreateMap<CategoryProduct, CategoryVM>()
                .ForMember(cvm => cvm.Name, opt => opt.MapFrom(cp => cp.Category.Name))
                .ForMember(cvm => cvm.Description, opt => opt.MapFrom(cp => cp.Category.Description))
                .ForMember(cvm => cvm.ImageUrl, opt => opt.MapFrom(cp => cp.Category.ImageUrl))
                .ForMember(cvm => cvm.Id, opt => opt.MapFrom(cp => cp.Category.Id));

            CreateMap<ProductVM, Product>()
               .ForMember(p => p.PriceIsInteger, opt => opt.MapFrom(pvm => pvm.PriceIsInteger ? "T" : "F"));

            


            CreateMap<CategoryAttribute, AttributeVM>()
                .ForMember(cvm => cvm.Required, opt => opt.MapFrom(c => c.Required == "T"))
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
