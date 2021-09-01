using Minyu.ApplicationCore.BudgetTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.ServiceInterface
{
   public interface IUserService
    {
        Task<IEnumerable<UserResponseModel>> GetAllUsers();
        Task<UserDetailResponseModel> GetUserDetail(int userId);
        //Task<List<UserDetailResponseModel>> GetAllUsers();

        Task<UserResponseModel> AddUser(AddUserRequestModel addUserRequestModel);
        Task DeleteUser(int userId);

        Task<UserResponseModel> UpdateUser(AddUserRequestModel addUserRequestModel);

        
    }
}
