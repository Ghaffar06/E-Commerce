using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return RedirectToAction("Edit", new { id = cat.Id });
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
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            Uow.CategoryRepo.Delete(id);
            Uow.SaveChanges();
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult AssignAttribute(int attr_id, int cat_id, string Requierd)
        {
            var Category = Uow.CategoryRepo.Get(cat_id);
            var Attribute = Uow.AttributeRepo.Get(attr_id);
            var categoryAttribute = new CategoryAttribute
            {
                Attribute = Attribute,
                Category = Category,
                Required = Requierd
            };
            Uow.CategoryAttributeRepo.Add(categoryAttribute);
            Uow.SaveChanges();
            return Json("catid: Success");
        }

        [HttpPost]
        public IActionResult ClearAssignmentAttribute(int categoryAttributeId)
        {
            Uow.CategoryAttributeRepo.Delete(categoryAttributeId);
            Uow.SaveChanges();
            return Json("catid: Success");
        }


        [HttpPost]

        public IActionResult ChangeRequirementAttribute(int attr_cat_id, string Requierd)
        {
            var categoryAttribute = Uow.CategoryAttributeRepo.Get(attr_cat_id);
            categoryAttribute.Required = Requierd;
            Uow.CategoryAttributeRepo.Update(categoryAttribute);
            Uow.SaveChanges();
            return Json("catid: Success");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
