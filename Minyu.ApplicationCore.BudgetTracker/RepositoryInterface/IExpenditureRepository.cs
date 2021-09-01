using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minyu.ApplicationCore.BudgetTracker.Entities;
using Minyu.ApplicationCore.BudgetTracker.RepositoryInterface;

namespace Minyu.ApplicationCore.BudgetTracker.RepositoryInterface
{
   public interface IExpenditureRepository :IAsyncRepository<Expenditure>
    {
        Task<decimal> GetTotalExpenditure(int userid);
    }
}
