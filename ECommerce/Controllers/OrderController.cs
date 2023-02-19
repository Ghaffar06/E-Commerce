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
        public async Task<IActionResult> Details(int orderId)
        {
            var order = await Uow.OrderRepo.GetAsync(orderId);
            if (order == null)
                return RedirectToAction("E404", "Home");
            var userId = await GetCurrentUserId();
            if (User.IsInRole("Admin") || order.CustomerId == userId || order.DelivererId == userId)
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
        public async Task<IActionResult> Accept(int orderId)
        {
            Order order = Uow.OrderRepo.Get(orderId);
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
        public async Task<IActionResult> Delivered(int orderId)
        {
            Order order = await Uow.OrderRepo.GetAsync(orderId);
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
            return RedirectToAction("Details", orderId);

        }


        [HttpPost]
        [Authorize(Roles = "Deliverer")]
        public async Task<IActionResult> AddStatusNote(int orderId, string note)
        {
            Order order = await Uow.OrderRepo.GetAsync(orderId);
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
            return RedirectToAction("Details", orderId);
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