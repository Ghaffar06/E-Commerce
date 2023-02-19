using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class ProductController : BaseController
    {

        public ProductController(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager)
            : base(uow, mapper, userManager)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(Mapper.Map<List<ProductVM>>(Uow.ProductRepo.GetAll()));
        }
        [HttpGet]
        public IActionResult Categoty(int categoryId)
        {
            List<Product> products = Uow.ProductRepo.GetAllByCategory(categoryId);
            List<ProductVM> productsVM = Mapper.Map<List<ProductVM>>(products);

            return View(productsVM);
        }


        [HttpGet]
        public IActionResult Index2()
        {
            return View(Mapper.Map<List<ProductVM>>(Uow.ProductRepo.GetAll()));
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductVM product, IFormFile uploadFile)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", "Validation Failed");
                return RedirectToAction("Create");
            }
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
            ViewData["categories"] = Mapper.Map<List<CategoryVM>>(Uow.CategoryRepo.GetAll());
            return View("EditCategory", prod);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ProductVM product, IFormFile uploadFile)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("error", "Validation Failed");
                return RedirectToAction("Edit", product.Id);
            }
            var prod = Mapper.Map<Product>(product);
            if (uploadFile != null)
                prod.ImageUrl = await Utilities.SaveFileAsync(uploadFile);
            Uow.ProductRepo.Update(prod);
            Uow.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpDelete]
        public IActionResult DeleteAttribute(int attr_val_id)
        {
            try
            {
                Uow.ProductAttributeRepo.Delete(attr_val_id);
                Uow.SaveChanges();
                return Json("FUCK IT!");
            }
            catch (Exception e)
            {

                return Json("no such attribute !");

            }
        }

        [HttpGet]
        public async Task<IActionResult> EditAttribute(int Id)
        {
            Product p = await Uow.ProductRepo.GetAsync(Id);
            if (p == null)
                return RedirectToAction("E404", "Home");
            var prod = Mapper.Map<ProductVM>(p);
            foreach (var v in prod.AttributeValues)
                v.IsDeletable = Uow.AttributeRepo.IsDeletable(prod.Id, v.Attribute.Id);

            ViewData["categories"] = Mapper.Map<List<CategoryVM>>(Uow.CategoryRepo.GetAll());
            return View(prod);
        }


        [HttpPost]
        public IActionResult AssignAttributeValue(int attr_id, int prod_id, string val)
        {


            try
            {
                Uow.ProductAttributeRepo.Add(new AttributeProductValue
                {
                    Attribute = Uow.AttributeRepo.Get(attr_id),
                    Product = Uow.ProductRepo.Get(prod_id),
                    Value = val
                });
                Uow.SaveChanges();

                return Json("Success!!");
            }
            catch (Exception ex)
            {
                return RedirectToAction("E404", "Home");

            }
        }

        [HttpPost]
        public IActionResult EditAttributeValue(int attr_val_id, string val)
        {
            Uow.ProductAttributeRepo.Get(attr_val_id).Value = val;
            Uow.SaveChanges();
            return Json("Success!!");
        }


        [HttpPost]
        public async Task<IActionResult> AssignCategories(List<int> category, int prod_id)
        {
            Product product = await Uow.ProductRepo.GetAsync(prod_id);

            List<int> existedCategories = new List<int>();
            foreach (var cat in product.CategoryProduct)
                existedCategories.Add(cat.CategoryId);

            foreach (var cat_id in category)
                if (!existedCategories.Contains(cat_id))
                {
                    Category category1 = await Uow.CategoryRepo.GetAsync(cat_id);
                    Uow.CategoryProductRepo.Add(new CategoryProduct
                    {
                        Product = Uow.ProductRepo.Get(prod_id),
                        Category = category1
                    });
                    foreach (var attr in category1.CategoryAttribute)
                        Uow.ProductAttributeRepo.Add(new AttributeProductValue
                        {
                            AttributeId = attr.AttributeId,
                            ProductId = prod_id,
                            Value = ""
                        });
                }
            foreach (var cat_id in existedCategories)
                if (!category.Contains(cat_id))
                    Uow.CategoryProductRepo.Delete((int)Uow.CategoryProductRepo.Find(new CategoryProduct
                    {
                        CategoryId = cat_id,
                        ProductId = prod_id
                    }));

            Uow.SaveChanges();
            return RedirectToAction("Edit", new { id = prod_id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {

            var pvv = await Uow.ProductRepo.GetAsync(Id);
            if (pvv == null)
                return RedirectToAction("E404", "Home");
            var v = Mapper.Map<ProductVM>(pvv);

            return View(v);
        }
    }
}
