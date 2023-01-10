using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;


namespace ECommerce.Controllers
{
    public class ProductController : BaseController
    {

        public ProductController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Create(CategoryViewModel category)
        //{
        //    return null;
        //}
        [HttpGet]
        public IActionResult EditCategory(int Id)
        {
            ViewData["categories"] = Mapper.Map<List<CategoryVM>>(Uow.CategoryRepo.GetAll());
            return View(Mapper.Map<ProductVM>(Uow.ProductRepo.Get(Id)));
        }


        [HttpPost]
        public IActionResult EditCategory(ProductVM product)
        {
            return Redirect("index");
        }


        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
