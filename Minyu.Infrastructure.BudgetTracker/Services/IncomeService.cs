
using Minyu.ApplicationCore.BudgetTracker.Entities;
using Minyu.ApplicationCore.BudgetTracker.Models;
using Minyu.ApplicationCore.BudgetTracker.RepositoryInterface;
using Minyu.ApplicationCore.BudgetTracker.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.Infrastructure.BudgetTracker.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncomeRepository _incomeRepository;
        public IncomeService(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public async Task<IncomeResponseModel> AddIncome(IncomeRequestModel model)
        {

            var income = new Income
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                IncomeDate = model.IncomeDate,
                Remarks = model.Remarks
            };
            var addIncome = await _incomeRepository.AddAsync(income);
            var incomeModel = new IncomeResponseModel
            {
                UserId = addIncome.UserId,
                Amount = addIncome.Amount,
                Description = addIncome.Description,
                IncomeDate = addIncome.IncomeDate,
                Remarks = addIncome.Remarks
            };
            return incomeModel;
        }

        public async Task DeleteIncome(int incomeid)
        {
            var income = await _incomeRepository.ListAsync(i => i.Id == incomeid);
            await _incomeRepository.DeleteAsync(income.First());
        }

        public async Task<IEnumerable<IncomeResponseModel>> GetAllIncomes()
        {
            var incomes = await _incomeRepository.ListAllAsync();
            List<IncomeResponseModel> incomemodel = new List<IncomeResponseModel>();

            foreach (var income in incomes)
            {
                incomemodel.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }


            return incomemodel;
        }

        public async Task<IEnumerable<IncomeResponseModel>> ListIncomesById(int userId)
        {
            var dbIncomes = await _incomeRepository.ListAsync(i => i.UserId == userId);
            if (!dbIncomes.Any())
            {
                throw new Exception("Income dose not exists");
            }
            List<IncomeResponseModel> incomemodel = new List<IncomeResponseModel>();
            foreach (var income in dbIncomes)
            {
                incomemodel.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }
            return incomemodel;
        }

        public async Task<IncomeResponseModel> UpdateIncome(IncomeRequestModel model)
        {
            var income = new Income
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                IncomeDate = model.IncomeDate,
                Remarks = model.Remarks
            };
            var updateIncome = await _incomeRepository.UpdateAsync(income);
            var incomeModel = new IncomeResponseModel
            {
                UserId = updateIncome.UserId,
                Amount = updateIncome.Amount,
                Description = updateIncome.Description,
                IncomeDate = updateIncome.IncomeDate,
                Remarks = updateIncome.Remarks
            };
            return incomeModel;
        }
    }

}

