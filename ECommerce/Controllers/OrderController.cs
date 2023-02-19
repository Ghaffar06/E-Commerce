using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class OrderController : BaseController
    {

        public OrderController(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager)
            : base(uow, mapper, userManager)
        {
        }

        [HttpGet]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> Waiting()
        {
            return Json(await Uow.OrderRepo.GetWaiting());
        }

        [HttpPost]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> Accept(int orderId)
        {
            return Json(await Uow.OrderRepo.GetWaiting());
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Requested()
        {
            return Json(await Uow.OrderRepo.GetRequested(await GetCurrentUserId()));
        }


    }
}