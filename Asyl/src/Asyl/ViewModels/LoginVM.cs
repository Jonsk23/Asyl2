using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter your username")]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Enter your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }
        
    }
}
