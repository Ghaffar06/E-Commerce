using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CategoryController : BaseController
    {

        public CategoryController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Mapper.Map<List<CategoryVM>>(Uow.CategoryRepo.GetAll()));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM category, IFormFile uploadFile)
        {
            Category cat = Mapper.Map<Category>(category);
            cat.ImageUrl = await Utilities.SaveFileAsync(uploadFile);
            Uow.CategoryRepo.Add(cat);
            Uow.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View(Mapper.Map<CategoryVM>(await Uow.CategoryRepo.GetAsync(Id)));
        }


        [HttpPost]
        public IActionResult Edit(CategoryVM category)
        {
            Category cat = Mapper.Map<Category>(category);
            Uow.CategoryRepo.Add(cat);
            Uow.SaveChanges();
            return Redirect("index");
        }

        [HttpPost]
        public IActionResult AssignAttribute(AttributeVM Attribute, int cat_id)
        {
            //Attribute attr = Mapper.Map<Attribute>(Attribute);
            //Category cat = Uow.CategoryRepo.Get(cat_id);
            //cat.CategoryAttribute.Add(new CategoryAttribute
            //{
            //    Id = cat_id,
            //    Attribute = attr
            //});
            //Uow.SaveChanges();
            return Json("catid: Success");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
