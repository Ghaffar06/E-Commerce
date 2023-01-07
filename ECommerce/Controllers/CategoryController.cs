using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace ECommerce.Controllers
{
    public class CategoryController : BaseController
    {
        private IMapper Mapper { get; set; }

        public CategoryController(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            this.Mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Mapper.Map<List<CategoryViewModel>>(_uow.CategoryRepo.GetAll()));
        }

        //public IActionResult Create(CategoryViewModel category)
        //{
        //    return null;
        //}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CategoryViewModel category)
        {
            var cat = Mapper.Map<Category>(category);
            _uow.CategoryRepo.Add(cat);
            _uow.SaveChanges();
            return Redirect("index");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
