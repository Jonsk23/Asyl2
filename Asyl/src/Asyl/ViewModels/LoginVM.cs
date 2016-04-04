using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Submit username")]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Submit password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }

    }
}
