using Minyu.ApplicationCore.BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.RepositoryInterface
{
   public interface IUserRepository: IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
