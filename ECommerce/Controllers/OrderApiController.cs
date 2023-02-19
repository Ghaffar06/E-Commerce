using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class OrderApiController : Controller
    {
        protected IUnitOfWork Uow { get; set; }
        protected IMapper Mapper { get; set; }
        public OrderApiController(IUnitOfWork uow, IMapper mapper)
            : base()
        {
            this.Uow = uow;
            this.Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderStatus(int Id)
        {
            var order = await Uow.OrderRepo.GetAsync(Id);
            if (order == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            var orderVM = Mapper.Map<List<ShortOrderStatusVM>>(order.OrderStatus);
            return Json(orderVM);
        }
    }
}
