using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minyu.ApplicationCore.BudgetTracker.ServiceInterface;
using Minyu.ApplicationCore.BudgetTracker.Models;

namespace Minyu.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;

        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenses()
        {
            Console.WriteLine("Debug2: Test on GET method.");
            var expense = await _expenditureService.GetAllExpenditure();
            if(expense == null)
            {
                Console.WriteLine("Debug1: Test on emepty expendicture");
                return NotFound("Expenditure Not Found");
            }
            Console.WriteLine("Debug3: Test on the success.");
            return Ok(expense);
        }


        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetExpensesByUserId(int userId)
        {
            var response = await _expenditureService.ListExpenditureById(userId);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenditure(ExpenditureRequestModel model)
        {
            var expense = await _expenditureService.AddExpenditure(model);
            if (expense == null)
            {
                return NotFound("Expenditure Not Found");
            }

            return Ok(expense);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateExpenditure(ExpenditureRequestModel model)
        {
            var expense = await _expenditureService.UpdateExpenditure(model);
            if (expense == null)
            {
                return BadRequest("Failed to Update Expenditure");
            }
            return Ok(expense);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteExpenditure(int id)
        {
            await _expenditureService.DeleteExpenditure(id);
            return Ok("Delete Successed!");
        }

    }
}
