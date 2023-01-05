using AppDbContext.IRepos;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDbContext.UOW
{
    public interface IUnitOfWork
    {
        public IStudentRepo StudentRepo { get; set; }

        public void SaveChanges ();

        public void RollBack();
    }
}
