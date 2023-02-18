using ECommerceDbContext.UOW;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Uow { get; set; }
        protected IMapper Mapper { get; set; }

        public BaseController(IUnitOfWork uow, IMapper mapper)
        {
            this.Uow = uow;
            this.Mapper = mapper;
        }
    }
}
