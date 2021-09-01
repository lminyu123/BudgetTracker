using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.RepositoryInterface
{
    public interface IAsyncRepository<T> where T: class
    {
        //CRUD
        Task<T> GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter=null);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter=null);
       
    }
}
