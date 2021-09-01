using Microsoft.EntityFrameworkCore;
using Minyu.ApplicationCore.BudgetTracker.Entities;
using Minyu.ApplicationCore.BudgetTracker.RepositoryInterface;
using Minyu.Infrastructure.BudgetTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.Infrastructure.BudgetTracker.Repositories
{
    public class IncomeRepository : EfRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<decimal> GetIncomeTotal(int userId)
        {
            var TotalIncome = await _dbContext.Incomes.Where(i => i.UserId == userId).DefaultIfEmpty().SumAsync(i => i.Amount);
            return TotalIncome;
        }

    }
}
