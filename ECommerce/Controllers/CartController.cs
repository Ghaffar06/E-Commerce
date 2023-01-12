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
        public CartController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(Mapper.Map<List<ProductVM>>(Uow.ProductRepo.GetAllAsync()));
        }
    }
}