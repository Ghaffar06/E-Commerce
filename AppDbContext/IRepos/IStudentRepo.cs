using AppDbContext.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppDbContext.IRepos
{
    public interface IStudentRepo : IBaseRepo<Student>
    {
        //IEnumerable<Student> GetByCourse(int id);
    }
}
