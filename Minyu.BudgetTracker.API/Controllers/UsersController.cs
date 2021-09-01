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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> AddUser(AddUserRequestModel model)
        {
            Console.WriteLine("*** Debug user controller: get into addUser()");
            var users = await _userService.AddUser(model);
            if (users == null)
            {
                return BadRequest("Failed to add User");
            }
            return Ok(users);
        }
        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> UpdateUser(AddUserRequestModel model)
        {
            var users = await _userService.UpdateUser(model);
            if (users == null)
            {
                return BadRequest("Failed to update User");
            }

            return Ok(users);
        }

        [HttpDelete]
        [Route("deleteuser/{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);

            return Ok("Delete Successed!");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUserDetail(int id)
        {
            var user = await _userService.GetUserDetail(id);
            if (user == null)
            {
                NotFound("User cannot find");
            }
            return Ok(user);
        }

        [HttpGet]
        [Route("getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {

            var users = await _userService.GetAllUsers();
            if (!users.Any())
            {
                return NotFound("No User Found");
            }
            return Ok(users);
        }
    }
}
