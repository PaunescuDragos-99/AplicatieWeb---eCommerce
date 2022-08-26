using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TemaPawFinal1.Models;

namespace TemaPawFinal1.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BookDbContext BookDbContext { get; set; }


        public RepositoryBase(BookDbContext bookDbContext)
        {
            this.BookDbContext = bookDbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.BookDbContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.BookDbContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.BookDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this.BookDbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            this.BookDbContext.Set<T>().Update(entity);
        }

    }
}
