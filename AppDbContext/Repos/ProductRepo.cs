using AppDbContext.IRepos;
using AppDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppDbContext.Repos
{
    public class ProductRepo : BaseRepo<Category>, IProductRepo
    {
        public ProductRepo(EcommerceDbContext db) : base(db) 
        {

        }

    }
}
