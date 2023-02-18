using ECommerceDbContext.Models;
using ECommerceDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

        [HttpPost]
        public IActionResult FindOrCreate(AttributeVM attribute)
        {
            var attr = Mapper.Map<Attribute>(attribute);
            attr.ValueTypeId = FindOrCreate(attr.ValueType);
            var id = Uow.AttributeRepo.Find(attr);
            if (id != null)
                return Json(id);

            Uow.AttributeRepo.Add(attr);
            Uow.SaveChanges();
            return Json(Uow.AttributeRepo.Find(attr));
        }


        private int FindOrCreate(ValueType vt)
        {
            int? vtypeId = Uow.ValueTypeRepo.Find(vt);
            if (vtypeId != null)
                return (int)vtypeId;
            Uow.ValueTypeRepo.Add(vt);
            Uow.SaveChanges();
            return (int) Uow.ValueTypeRepo.Find(vt);
        }

    }
}
