using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MVCNTier.Core.Entities;
using MVCNTier.Core.Entities.Enums;
using MVCNTier.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVCNTier.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
    {

        private readonly AppDbContext appDbContext;
        protected DbSet<T> table;

        public BaseRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
            table = appDbContext.Set<T>();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> expression)
        {
            return await table.AnyAsync(expression);
        }

        public async Task Create(T entity)
        {
            table.Add(entity);
            await appDbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            entity.DeleteTime = DateTime.Now;
            entity.Status = Status.Passive;
            appDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllWhere(Expression<Func<T, bool>> expression)
        {
            return await table.Where(expression).ToListAsync();
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = table;
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if(orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }

        }

        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
        {
            IQueryable<T> query = table;
            if (includes != null) query = includes(query);
            if (expression != null) query = query.Where(expression);
            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).ToListAsync();
            }
            else
            {
                return await query.Select(selector).ToListAsync();
            }
        }

        public async Task<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return await table.FirstOrDefaultAsync(expression);
        }

        public bool Update(T entity)
        {
            appDbContext.Entry<T>(entity).State = EntityState.Modified;
            bool result = appDbContext.SaveChanges() > 0;
            return result;
        }
    }
}
