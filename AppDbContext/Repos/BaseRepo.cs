using AppDbContext.IRepos;
using AppDbContext.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppDbContext.Repos
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        protected EcommerceDbContext _db;

        private DbSet<T> _dbSet;
        public BaseRepo(EcommerceDbContext db)
        {
            _db = db;
            _dbSet = db.Set<T>();
        }

        public async void Add(T item)
        {
            await _dbSet.AddAsync(item);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> predicate = null)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
                query = predicate(query);
            return query.ToList();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }
}
