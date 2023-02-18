using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceDbContext.IRepos
{
    public interface IBaseRepo<T> where T : class
    {
        T Get(int id);

        void Add(T item);

        void Update(T item);

        void Delete(int id);

        IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> predicate = null);
    }
}
