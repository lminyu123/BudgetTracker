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
    public class ExpenditureService : IExpenditureService
    {
        private readonly IExpenditureRepository _expenditureRepository;
        public ExpenditureService(IExpenditureRepository expenditureRepository)
        {
            _expenditureRepository = expenditureRepository;
        }
        public async Task<ExpenditureResponseModel> AddExpenditure(ExpenditureRequestModel model)
        {
            var expenditure = new Expenditure
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            var addexpenditure = await _expenditureRepository.AddAsync(expenditure);
            var expendituremodel = new ExpenditureResponseModel
            {
                UserId = addexpenditure.UserId,
                Amount = addexpenditure.Amount,
                Description = addexpenditure.Description,
                ExpDate = addexpenditure.ExpDate,
                Remarks = addexpenditure.Remarks
            };
            return expendituremodel;
        }

        public async Task DeleteExpenditure(int expenditureid)
        {
            var expenditure = await _expenditureRepository.ListAsync(i => i.Id == expenditureid);
            await _expenditureRepository.DeleteAsync(expenditure.First());
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> GetAllExpenditure()
        {
            var expenditures = await _expenditureRepository.ListAllAsync();
            List<ExpenditureResponseModel> model = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                model.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }
            return model;
        }

        public async Task<IEnumerable<ExpenditureResponseModel>> ListExpenditureById(int userId)
        {
            var expenditures = await _expenditureRepository.ListAsync(i => i.UserId == userId);
            if (!expenditures.Any())
            {
                throw new Exception("Expenditure not found");
            }
            List<ExpenditureResponseModel> model = new List<ExpenditureResponseModel>();
            foreach (var expenditure in expenditures)
            {
                model.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate = expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }
            return model;
        }

        public async Task<ExpenditureResponseModel> UpdateExpenditure(ExpenditureRequestModel model)
        {
            var expense = new Expenditure
            {
                UserId = model.UserId,
                Amount = model.Amount,
                Description = model.Description,
                ExpDate = model.ExpDate,
                Remarks = model.Remarks
            };
            var updateExpense = await _expenditureRepository.UpdateAsync(expense);
            var expendituremodel = new ExpenditureResponseModel
            {
                Id = updateExpense.Id,
                UserId = updateExpense.UserId,
                Amount = updateExpense.Amount,
                Description = updateExpense.Description,
                ExpDate = updateExpense.ExpDate,
                Remarks = updateExpense.Remarks
            };
            return expendituremodel;
        }
    }
}
