using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Minyu.ApplicationCore.BudgetTracker.Entities
{
   public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        public DateTime? JoinedOn { get; set; }


        public ICollection<Income> Incomes;
        public ICollection<Expenditure> Expenditures;
    }
}
