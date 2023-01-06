using AppDbContext.IRepos;
using AppDbContext.Models;
using AppDbContext.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDbContext.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepo CategoryRepo { get; set; }

        protected readonly EcommerceDbContext _db;

        public UnitOfWork(EcommerceDbContext db)
        {
            _db = db;
            CategoryRepo = new CategoryRepo(db);
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
