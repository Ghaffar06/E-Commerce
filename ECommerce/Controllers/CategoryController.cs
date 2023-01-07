using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            return View("Create23");
            //return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryVM category, IFormFile uploadFile)
        {

            var cat = Mapper.Map<Category>(category);
            if (uploadFile != null && uploadFile.Length > 0)
            {
                var fileName = Path.GetFileName(uploadFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/data", fileName);
                cat.ImageUrl = filePath;
                using (var fileSrteam = new FileStream(filePath, FileMode.Create))
                {
                    await uploadFile.CopyToAsync(fileSrteam);
                }
            }
            Uow.CategoryRepo.Add(cat);
            Uow.SaveChanges();
            return Redirect("index");
        }

        [HttpGet]
        public IActionResult Edit(long Id)
        {
            var c = Uow.CategoryRepo.Get(Id);
            var cat = Mapper.Map<CategoryVM>(c);

            return View(cat);
        }


        [HttpPost]
        public IActionResult Edit(CategoryVM category)
        {
            var cat = Mapper.Map<Category>(category);
            Uow.CategoryRepo.Add(cat);
            Uow.SaveChanges();
            return Redirect("index");
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
