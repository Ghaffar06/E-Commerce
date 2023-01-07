using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppDbContext.IRepos
{
    public interface IBaseRepo<T> where T : class
    {
        T Get(long id);

        // T Get(string id);

        void Add(T item);

        void Update(T item);

        void Delete(long id);

        IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> predicate = null);
    }
}
