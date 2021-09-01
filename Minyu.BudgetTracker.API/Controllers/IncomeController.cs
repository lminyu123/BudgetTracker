using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minyu.ApplicationCore.BudgetTracker.Models;
using Minyu.ApplicationCore.BudgetTracker.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minyu.BudgetTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
            private readonly IIncomeService _incomeService;

            public IncomeController(IIncomeService incomeService)
            {
                _incomeService = incomeService;
            }
        
        [HttpGet]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();
            
            if (!incomes.Any())
            {
                return NotFound("Income Not Found");
            }

            return Ok(incomes);
        }

        //[HttpGet("{UserId:int}")]
        //public async Task<IActionResult> GetIncomeByUserId(int UserId)
        //{
        //    var incomes = await _incomeService.(UserId);
        //    return Ok(incomes);
        //}


        [HttpPost]
        public async Task<IActionResult> AddIncome(IncomeRequestModel model)
        {
            var incomes = await _incomeService.AddIncome(model);
            if(incomes == null)
            {
                return BadRequest("Failed to Add Income");
            }
            return Ok(incomes);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIncome(IncomeRequestModel model)
        {
             var incomes=await _incomeService.UpdateIncome(model);
            if (incomes == null)
            {
                return BadRequest("Failed to Update Income");
            }
            return Ok(incomes);
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
           await _incomeService.DeleteIncome(id);
            return Ok("Delete Successed!");
        }
    }
}
