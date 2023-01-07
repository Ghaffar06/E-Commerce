﻿using AppDbContext.IRepos;
using AppDbContext.Models;
using AppDbContext.Repos;

namespace AppDbContext.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; set; }
        public IProductRepo ProductRepo { get; set; }
        public IAttributeRepo AttributeRepo { get; set; }

        protected readonly EcommerceDbContext _db;

        public UnitOfWork(EcommerceDbContext db)
        {
            _db = db;
            CategoryRepo = new CategoryRepo(db);
            ProductRepo = new ProductRepo(db);
            AttributeRepo = new AttributeRepo(db);
        }

        public void RollBack()
        {
            _db.Dispose();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
