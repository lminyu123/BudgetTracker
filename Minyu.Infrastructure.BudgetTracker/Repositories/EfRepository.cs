using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Minyu.ApplicationCore.BudgetTracker.RepositoryInterface;
using Minyu.Infrastructure.BudgetTracker.Data;
using Microsoft.EntityFrameworkCore;

namespace Minyu.Infrastructure.BudgetTracker.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        //dbcontext
        
        protected readonly BudgetTrackerDbContext _dbContext;
        public EfRepository(BudgetTrackerDbContext dbContext)
        {
            //injecting 
            _dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {

            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
             _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<bool> GetExistsAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter = null)
        {
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter = null)
        {
            var data = await _dbContext.Set<T>().Where(filter).ToListAsync();
            return data;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
