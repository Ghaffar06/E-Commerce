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
        public IStudentRepo StudentRepo { get; set; }

        protected readonly TestDbContext _db;

        public UnitOfWork(TestDbContext db)
        {
            _db = db;
            StudentRepo = new StudentRepo(db);
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
