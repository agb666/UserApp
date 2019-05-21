using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserApp.Models
{
    public class User
    {
        
        [Required]
        public int ID { get; set;}

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "You Must Enter a Valid Email Address")]
        [Required]
        public string Email { get; set; }
           
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} charater long.", MinimumLength = 8)]
        //[MembershipPassword(
        //    MinRequiredNonAlphanumericCharacters = 1,
        //     MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        //    ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc)."
        //        )]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string Password { get; set; }

    }
}
