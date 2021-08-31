using Microsoft.EntityFrameworkCore;
using Minyu.ApplicationCore.BudgetTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.Infrastructure.BudgetTracker.Data
{
   public class BudgetTrackerDbContext:DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {
            
        }
        //dbset create table
        public DbSet<User> Users { get; set; }
        //public DbSet<Income>Incomes { get; set; }
        //public DbSet<Expenditure> Expenditures { get; set; }
    }
}
