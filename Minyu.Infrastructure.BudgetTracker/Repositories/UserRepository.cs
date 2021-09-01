using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minyu.ApplicationCore.BudgetTracker.Entities;
using Minyu.ApplicationCore.BudgetTracker.RepositoryInterface;
using Minyu.Infrastructure.BudgetTracker.Data;

namespace Minyu.Infrastructure.BudgetTracker.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(BudgetTrackerDbContext dbContext) : base(dbContext)
        {

        }
       
        public override async Task<User> GetByIdAsync(int id)
        {
            //selecr all id from users
            var users = await  _dbContext.Users.Include(u => u.Incomes).Include(u => u.Expenditures).FirstOrDefaultAsync(u => u.Id == id);
            return users;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
