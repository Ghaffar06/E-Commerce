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
        public IActionResult Index()
        {
            var Products = Uow.ProductRepo.GetAllAsync();
            //var Products = Uow.ProductRepo.GetAllAsync(filter: p => p.Quantity > 0);
            var ProductsVM = Mapper.Map<List<ProductVM>>(Products);
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
            ViewData["OrderProductVM"] = orderProducts;
            return View(ProductsVM);
        }

        [HttpPost]
        public IActionResult AddToCart(int prod_id, decimal quantity)
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

        [HttpGet]
        public async Task<IActionResult> MyCart(int prod_id, decimal quantity)
        {
            if (HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts) == default)
                HttpContext.Session.Set(SessionKeyProducts, new List<OrderProductVM>());

            List<OrderProductVM> orderProducts = HttpContext.Session.Get<List<OrderProductVM>>(SessionKeyProducts);
            foreach (var orderProduct in orderProducts)
            {
                var product = await Uow.ProductRepo.GetAsync(orderProduct.ProductId);
                var productVM = Mapper.Map<ProductVM>(product);
                orderProduct.Product = productVM;
            }
            return View(orderProducts);
        }
    }
}