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
                .ForMember(c => c.Products, opt => opt.MapFrom(c => c.CategoryProduct))
                .ReverseMap();

            CreateMap<Product, ProductVM>()
               .ForMember(pvm => pvm.PriceIsInteger, opt => opt.MapFrom(p => p.PriceIsInteger == "T"))
               .ForMember(pvm => pvm.Categories, opt => opt.MapFrom(p => p.CategoryProduct))
               .ForMember(pvm => pvm.AttributeValues, opt => opt.MapFrom(p => p.AttributeProductValue));



            CreateMap<CategoryProduct, CategoryVM>()
                .ForMember(cvm => cvm.Name, opt => opt.MapFrom(cp => cp.Category.Name))
                .ForMember(cvm => cvm.Description, opt => opt.MapFrom(cp => cp.Category.Description))
                .ForMember(cvm => cvm.ImageUrl, opt => opt.MapFrom(cp => cp.Category.ImageUrl))
                .ForMember(cvm => cvm.Id, opt => opt.MapFrom(cp => cp.Category.Id));

            CreateMap<CategoryProduct, ProductVM>()
                .ForMember(cvm => cvm.Id, opt => opt.MapFrom(cp => cp.Product.Id))
                .ForMember(cvm => cvm.Name, opt => opt.MapFrom(cp => cp.Product.Name))
                .ForMember(cvm => cvm.Description, opt => opt.MapFrom(cp => cp.Product.Description))
                .ForMember(cvm => cvm.Price, opt => opt.MapFrom(cp => cp.Product.Price))
                .ForMember(cvm => cvm.PriceIsInteger, opt => opt.MapFrom(cp => cp.Product.PriceIsInteger == "T"))
                .ForMember(cvm => cvm.Quantity, opt => opt.MapFrom(cp => cp.Product.Quantity))
                .ForMember(cvm => cvm.ImageUrl, opt => opt.MapFrom(cp => cp.Product.ImageUrl))
                .ForMember(cvm => cvm.Unit, opt => opt.MapFrom(cp => cp.Product.Unit));


            CreateMap<AttributeProductValue, AttributeValuesVM>()
                .ForMember(atvm => atvm.Id, opt => opt.MapFrom(at => at.Id))
                .ForMember(atvm => atvm.Value, opt => opt.MapFrom(at => at.Value))
                .ForMember(atvm => atvm.Attribute, opt => opt.MapFrom(at => at.Attribute));


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
                .ForMember(attr => attr.Description, opt => opt.MapFrom(vm => vm.Description))
                .ForMember(attr => attr.ValueType, opt => opt.MapFrom(vm => vm.ValueType))
                .ReverseMap();

            CreateMap<ValueType, ValueTypeVM>()
                .ReverseMap();

            CreateMap<OrderVM, Order>()
                .ReverseMap();
            CreateMap<OrderStatusVM, OrderStatus>()
                .ReverseMap();
            CreateMap<OrderProductVM, OrderProduct>()
                .ReverseMap();
        }
    }
}
