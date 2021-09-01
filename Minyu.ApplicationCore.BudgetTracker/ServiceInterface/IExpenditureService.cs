using Minyu.ApplicationCore.BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.ServiceInterface
{
    public interface IExpenditureService
    {
        Task<ExpenditureResponseModel> AddIncome(ExpenditureResponseModel expenditureRequestModel);
        Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel expenditureResponseModel);
        Task DeleteIncome(int expenditureid);
        Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditure();
        Task<IEnumerable<ExpenditureResponseModel>> ListExpenditureById(int userId);
    }
}
