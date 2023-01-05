using AppDbContext.IRepos;
using AppDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppDbContext.Repos
{
    public class StudentRepo : BaseRepo<Student>, IStudentRepo
    {
        public StudentRepo(TestDbContext db) : base(db) 
        {

        }

    }
}
