using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.Entities
{
   public class Expenditure
    {
        public int Id { get; set; }
        
        //foregin key
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public DateTime? ExpDate { get; set; }
        
        //navgation property
        public User User { get; set; }
    }
}
