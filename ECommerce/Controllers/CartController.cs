using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CartController : BaseController
    {

        const string SessionKeyProducts = "_Products";

        public CartController(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager)
            : base(uow, mapper, userManager)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<OrderProductVM> orderProducts = OrderProductSession();

            ViewData["OrderProductVM"] = orderProducts;

            List<ProductVM> productsVM = new List<ProductVM>();

            foreach (var orderProduct in orderProducts)
            {
                var product = await Uow.ProductRepo.GetAsync(orderProduct.ProductId);
                productsVM.Add(Mapper.Map<ProductVM>(product));
            }

            return View(productsVM);
        }

        [HttpPost]
        public IActionResult ChangeQuantityCart(int prod_id, double quantity)
        {
            List<OrderProductVM> orderProducts = OrderProductSession();

            int Idx = orderProducts.FindIndex(q => q.ProductId == prod_id);
            if (Idx == -1)
            {
                orderProducts.Add(new OrderProductVM
                {
                    ProductId = prod_id,
                    Quantity = quantity
                });
                Idx = orderProducts.Count - 1;
            }
            else
                orderProducts[Idx].Quantity = quantity;

            if (orderProducts[Idx].Quantity <= 0)
                orderProducts.RemoveAt(Idx);

            HttpContext.Session.Set(SessionKeyProducts, orderProducts);

            return Json("Success!!");
        }

        [HttpPost]
        public IActionResult AddToCart(int prod_id, double quantity)
        {
            List<OrderProductVM> orderProducts = OrderProductSession();

            int Idx = orderProducts.FindIndex(q => q.ProductId == prod_id);
            if (Idx == -1)
            {
                orderProducts.Add(new OrderProductVM
                {
                    ProductId = prod_id,
                    Quantity = 0
                });
                Idx = orderProducts.Count - 1;
            }

            orderProducts[Idx].Quantity += quantity;

            if (orderProducts[Idx].Quantity <= 0)
                orderProducts.RemoveAt(Idx);

            HttpContext.Session.Set(SessionKeyProducts, orderProducts);

            return Json("Success!!");
        }

        /*[HttpPost]
        public IActionResult SubmitOrder(OrderVM orderVM)
        {
            

            List<OrderProductVM> orderProducts = new List<OrderProductVM>();
            int Idx = orderProducts.FindIndex(q => q.ProductId == prod_id);
            if (Idx == -1)
            {
                orderProducts.Add(new OrderProductVM
                {
                    ProductId = prod_id,
                    Quantity = quantity
                });
                Idx = orderProducts.Count - 1;
            }
            else
                orderProducts[Idx].Quantity = quantity;

            if (orderProducts[Idx].Quantity <= 0)
                orderProducts.RemoveAt(Idx);

            HttpContext.Session.Set(SessionKeyProducts, orderProducts);

            return Json("Success!!");
        }
        */

        [HttpPost]
        public IActionResult DeleteFromCart(int prod_id)
        {
            List<OrderProductVM> orderProducts = OrderProductSession();

            int Idx = orderProducts.FindIndex(q => q.ProductId == prod_id);
            if (Idx == -1)
            {
                return Json("No Such Product!!");
            }

            orderProducts.RemoveAt(Idx);

            HttpContext.Session.Set(SessionKeyProducts, orderProducts);

            return Json("Success!!");
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            List<OrderProductVM> orderProducts = OrderProductSession();


            double totalPrice = 0;
            foreach (var orderProduct in orderProducts)
            {
                var product = await Uow.ProductRepo.GetAsync(orderProduct.ProductId);
                var productVM = Mapper.Map<ProductVM>(product);
                orderProduct.Product = productVM;
                totalPrice += product.Price * orderProduct.Quantity;
            }
            OrderVM orderVM = new OrderVM()
            {
                OrderProduct = orderProducts,
                TotalPrice = totalPrice,
            };
            return View(orderVM);
        }


        [HttpPost]
        public async Task<IActionResult> CheckOut(OrderVM orderVM)
        {
            Order order = Mapper.Map<Order>(orderVM);
            order.CustomerId = await GetCurrentUserId();
            order.TotalPrice = 0m;
            order.CreatedAt = DateTime.Now;
            order.OrderStatus.Add(new OrderStatus()
            {
                State = "Waiting",
                Note = "The order has been accepted by a deliverer"
            });

            bool checkQuantity = true;
            foreach (var orderProduct in order.OrderProduct)
            {
                Product product = Uow.ProductRepo.Get(orderProduct.ProductId);
                if (orderProduct.Quantity > product.Quantity)
                    checkQuantity = false;
                product.Quantity -= orderProduct.Quantity;
                Uow.ProductRepo.Update(product);
                order.TotalPrice += orderProduct.Quantity * (decimal)product.Price;
            }

            if (checkQuantity)
            {
                Uow.OrderRepo.Add(order);
                Uow.SaveChanges();
                HttpContext.Session.Remove(SessionKeyProducts);
                return Json("On the way");
            }
            else
                return Json("No enouph quantity!!");
        }




        /*[HttpPost]
        public async Task<IActionResult> MyCartAsync(OrderVM orderVM)
        {
            bool checkQuantity = true;
            foreach(var orderProduct in orderVM.OrderProduct)
            {
                Product product = await Uow.ProductRepo.GetAsync(orderProduct.ProductId);
                if (orderProduct.Quantity > (double) product.Quantity)
                    checkQuantity = false;
            }
            if (checkQuantity)
            {
                Order order = Mapper.Map<Order>(orderVM);
                Uow.OrderRepo.Add(order);
                Uow.SaveChanges();
                int id = HttpContext.Request.QueryString["id"];
                return View(Mapper.Map<List<OrderVM>>(Uow.OrderRepo.GetAllById()));
            }
            
            return Json("No enouph quantity!!");

        }*/


        /* [HttpGet]
		 public IActionResult ViewMyOrders()
		 {
			 var Products = Uow.OrderRepo.GetAllAsync(filter: p => p.Quantity > 0);
			 //var Products = Uow.ProductRepo.GetAllAsync(filter: p => p.Quantity > 0);
			 var ProductsVM = Mapper.Map<List<ProductVM>>(Products);
			 if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
				 HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

			 List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
			 ViewData["OrderProductVM"] = orderProducts;
			 return View(ProductsVM);

		 }*/


        private List<OrderProductVM> OrderProductSession()
        {
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);

            return orderProducts;
        }
    }
}