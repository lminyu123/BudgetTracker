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
    public class ExpenditureRepository: EfRepository<Expenditure>, IExpenditureRepository
    {
        public ExpenditureRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {
        }
            public async Task<decimal> GetTotalExpenditure(int userId)
        {
            var TotalExpenditure = await _dbContext.Expenditures.Where(i => i.UserId == userId).DefaultIfEmpty().SumAsync(i => i.Amount);
            return TotalExpenditure;
        }
        

    }
}
