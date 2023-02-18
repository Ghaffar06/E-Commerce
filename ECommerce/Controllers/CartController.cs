using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CartController : BaseController
    {

        const string SessionKeyProducts = "_Products";

        public CartController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
            ViewData["OrderProductVM"] = orderProducts;

            List < ProductVM > productsVM = new List < ProductVM >(); 

            foreach (var orderProduct in orderProducts)
            {
                var product = await Uow.ProductRepo.GetAsync(orderProduct.ProductId);
                productsVM.Add(Mapper.Map<ProductVM>(product));
            }

            return View(productsVM);
        }

        [HttpPost]
        public IActionResult AddToCart(int prod_id, double quantity)
        {
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
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
        public IActionResult DeleteFromCart(int prod_id)
        {
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
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
        public async Task<IActionResult> MyCart()
        {
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
            
            
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
        public IActionResult MyCart(OrderVM orderVM)
        {
            Order order = Mapper.Map<Order>(orderVM);
            Uow.OrderRepo.Add(order);
            Uow.SaveChanges();
            return Json("Success!!");

        }
    }
}