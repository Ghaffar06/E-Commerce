using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var orders = await Uow.OrderRepo.GetWaiting();
            var ordersVM = Mapper.Map<List<OrderVM>>(orders);
            return View(ordersVM);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Details(int Id)
        {
            var order = await Uow.OrderRepo.GetAsync(Id);
            var userId = await GetCurrentUserId();
            if (User.IsInRole("Admin") ||
                order.CustomerId == userId ||
                order.DelivererId == userId ||
                (order.DelivererId == null && User.IsInRole("Deliverer")))
            {
                var ordersVM = Mapper.Map<OrderVM>(order);
                return View(ordersVM);
            }
            else
            {
                return Unauthorized();
            }
        }


        [HttpGet]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> AcceptedOrder()
        {
            var DelivererId = await GetCurrentUserId();
            var orders = await Uow.OrderRepo.GetAccepted(DelivererId);
            var ordersVM = Mapper.Map<List<OrderVM>>(orders);
            return View(ordersVM);
        }

        [HttpPost]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> Accept(int Id)
        {
            Order order = Uow.OrderRepo.Get(Id);
            if (order.DelivererId == null)
            {
                order.DelivererId = await GetCurrentUserId();
                order.OrderStatus.Add(new OrderStatus()
                {
                    State = "On Thw Way",
                    Note = "The order has been accepted by a deliverer"
                });
                Uow.OrderRepo.Update(order);
                Uow.SaveChanges();
                ViewData["Message"] = "The order is your responsibility now";
            }
            else
            {
                ViewData["Message"] = "The order is not available";
            }
            return RedirectToAction("Waiting");
        }

        [HttpPost]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> Delivered(int Id)
        {
            Order order = await Uow.OrderRepo.GetAsync(Id);
            var DelivererId = await GetCurrentUserId();
            if (order.DelivererId != DelivererId)
                return Unauthorized();
            order.OrderStatus.Add(new OrderStatus()
            {
                State = "Delivered",
                Note = "The request has been delivered"
            });
            Uow.OrderRepo.Update(order);
            Uow.SaveChanges();
            return RedirectToAction("Details", new { Id });

        }


        [HttpPost]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> AddStatusNote(int Id, string note)
        {
            Order order = await Uow.OrderRepo.GetAsync(Id);
            var DelivererId = await GetCurrentUserId();
            if (order.DelivererId != DelivererId)
                return Unauthorized();

            order.OrderStatus.Add(new OrderStatus()
            {
                State = "On The Way",
                Note = note
            });
            Uow.OrderRepo.Update(order);
            Uow.SaveChanges();
            return RedirectToAction("Details", new { Id });
        }


        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Requested()
        {
            var orders = await Uow.OrderRepo.GetRequested(await GetCurrentUserId());
            var ordersVM = Mapper.Map<List<OrderVM>>(orders);
            return Json(await Uow.OrderRepo.GetRequested(await GetCurrentUserId()));
        }


    }
}