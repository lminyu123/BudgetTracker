using Minyu.ApplicationCore.BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.ServiceInterface
{
    public interface IIncomeService
    {
        Task<IncomeResponseModel> AddIncome(IncomeRequestModel incomeRequestModel);
        Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel incomeRequestModel);
        Task DeleteIncome(int incomeid);
        Task<IEnumerable<IncomeResponseModel>> GetAllIncomes();
        Task<IEnumerable<IncomeResponseModel>> ListIncomesById(int userId);
    }
}
