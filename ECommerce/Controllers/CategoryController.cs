using AppDbContext.UOW;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.Controllers
{
    public class CategoryController : BaseController
    {

        public CategoryController(IUnitOfWork uow) : base(uow)
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

        public IActionResult Create()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
