using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AttributeController : BaseController
    {
        public AttributeController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Mapper.Map<List<AttributeVM>>(Uow.AttributeRepo.GetAll(predicate: query => query.Include(p => p.ValueType))));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AttributeVM attribute)
        {
            var attr = Mapper.Map<Attribute>(attribute);
            Uow.AttributeRepo.Add(attr);
            Uow.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public  IActionResult Edit(int Id)
        {
            return View();
            //return View(Mapper.Map<AttributeVM>(await Uow.CategoryRepo.GetAsync(Id)));
        }


        [HttpPost]
        public IActionResult Edit(AttributeVM attribute)
        {
            Attribute attr = Mapper.Map<Attribute>(attribute);
            //Uow.CategoryRepo.Add(cat);
            Uow.SaveChanges();
            return Redirect("index");
        }
    }
}
