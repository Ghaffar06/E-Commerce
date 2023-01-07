using AppDbContext.Models;
using AutoMapper;

namespace ECommerce.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
    }
}
