using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minyu.ApplicationCore.BudgetTracker.Models
{
    public class AddUserRequestModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Email should be in right format")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Password must be at least 5 characters long", MinimumLength = 5)]
        //[RegularExpression("^ (?=.*[a - z])(?=.*[A - Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{5,}$", 
        // ErrorMessage ="Password should have minimum 5 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
        
        [StringLength(50)]
        [Required(ErrorMessage = "Your Name cannot be empty")]
        public string Fullname { get; set; }
        public DateTime? JoinedOn { get; set; }
    }
}
