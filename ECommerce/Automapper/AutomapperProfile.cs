using AppDbContext.Models;
using AutoMapper;
using ECommerce.Models;

namespace ECommerce.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
        }
    }
}
