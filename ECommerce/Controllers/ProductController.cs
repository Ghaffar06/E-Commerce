﻿using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using AppDbContext.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class ProductController : BaseController
    {

        public ProductController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public IActionResult Index()
        {
            return View(Mapper.Map<List<ProductVM>>(Uow.ProductRepo.GetAll()));
        }

       
        //public IActionResult Create(CategoryViewModel category)
        //{
        //    return null;
        //}
        




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM product, IFormFile uploadFile)
        {

            var prod = Mapper.Map<Product>(product);
            prod.ImageUrl = await Utilities.SaveFileAsync(uploadFile);
            Uow.ProductRepo.Add(prod);
            Uow.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var p = await Uow.ProductRepo.GetAsync(Id);
            var prod = Mapper.Map<ProductVM>(p);
            return View(prod);
        }


        [HttpPost]
        public IActionResult Edit(ProductVM product)
        {
            var prod = Mapper.Map<Product>(product);
            Uow.ProductRepo.Add(prod);
            Uow.SaveChanges();
            return Redirect("index");
        }

        [HttpPost]
        public IActionResult AssignAttributeValue(AttributeVM attribute,string val, int prod_id)
        {
            var attr = Mapper.Map<Attribute>(attribute);
            var prod = Uow.ProductRepo.Get(prod_id);
            prod.AttributeProductValue.Add(new AttributeProductValue
            {
                Id = prod_id,
                Value = val,
                Attribute = attr
            });
            Uow.SaveChanges();
            return Json("prodid:" + prod_id + ",value:" + val + ",Attribute:" + attribute.Name);
        }

        [HttpPost]
        public IActionResult AssignCategory(List<int> category_ids, int prod_id)
        {
            foreach(var category in category_ids)
            {
                Uow.CategoryProductRepo.Add(new CategoryProduct
                {
                    Product = Uow.ProductRepo.Get(prod_id),
                    Category = Uow.CategoryRepo.Get(category)
                });
            }
            Uow.SaveChanges();
            return RedirectToAction("Edit", new {id = prod_id});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
