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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponseModel> AddUser(AddUserRequestModel model)
        {
            Console.WriteLine("***Debug user service: get into the AddUser()");
            var dbUser = _userRepository.GetUserByEmail(model.Email);
            //Console.WriteLine($"*** Check dbUser + {dbUser.Id} + email: {dbUser.}");
            if (dbUser != null)
            {
                throw new Exception("The User already exists");
            }
            
            var user = new User
            {

                Email = model.Email,
                Password = model.Password,
                FullName = model.Fullname,
                JoinedOn = DateTime.Now
            };
            Console.WriteLine("***Debug User services: Before AddAsync()");
            var createdUser = await _userRepository.AddAsync(user);
            Console.WriteLine("***Debug User services: after AddAsync()");
            var userResponseModel = new UserResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FullName = createdUser.FullName,
                JoinedOn = createdUser.JoinedOn
            };
            return userResponseModel;
        }
        public async Task DeleteUser(int userId)
        {
            var dbUser = await _userRepository.ListAsync(u => u.Id == userId);
            if (!dbUser.Any())
            {
                throw new Exception("Not Found, cannot be deleted!");
            }
             await _userRepository.DeleteAsync(dbUser.First());
            
        }

        public async Task<IEnumerable<UserResponseModel>> GetAllUsers()
        {
            var users = await _userRepository.ListAllAsync();
            var userdetail = new List<UserResponseModel>();
            foreach (var user in users)
            {
                userdetail.Add(new UserResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    JoinedOn = user.JoinedOn
                });
            }
            return userdetail;
        }

        public async Task<UserDetailResponseModel> GetUserDetail(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            //TODO: Have to validate the user object

            var responseModel = new UserDetailResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                
                Incomes = new List<IncomeResponseModel>()
            };
            responseModel.Expenditures = new List<ExpenditureResponseModel>();
            foreach (var expenditure in user.Expenditures)
            {
                responseModel.Expenditures.Add(new ExpenditureResponseModel
                {
                    Id = expenditure.Id,
                    UserId = expenditure.UserId,
                    Amount = expenditure.Amount,
                    Description = expenditure.Description,
                    ExpDate= expenditure.ExpDate,
                    Remarks = expenditure.Remarks
                });
            }
            responseModel.Incomes = new List<IncomeResponseModel>();
            foreach (var income in user.Incomes)
            {
                responseModel.Incomes.Add(new IncomeResponseModel
                {
                    Id = income.Id,
                    UserId = income.UserId,
                    Amount = income.Amount,
                    Description = income.Description,
                    IncomeDate = income.IncomeDate,
                    Remarks = income.Remarks
                });
            }
            return responseModel;
        }

        public async Task<UserResponseModel> UpdateUser(AddUserRequestModel model)
        {
            var dbUser = await _userRepository.GetByIdAsync(model.Id);
            if (dbUser == null)
            {
                throw new Exception("The User Not Found");
            }
            var user = new User
            {
                Id = model.Id,
                Email = model.Email,
                Password = model.Password,
                FullName = model.Fullname,
                JoinedOn = model.JoinedOn,
            };
            var uptUser = await _userRepository.UpdateAsync(user);
            var userResponseModel = new UserResponseModel
            {
                Id = uptUser.Id,
                FullName = uptUser.FullName,
                Email = uptUser.Email,
                JoinedOn = uptUser.JoinedOn
            };
            return userResponseModel;
        }

        
    }
}

    

        