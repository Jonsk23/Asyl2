using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Ange användarnamn")]
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Ange lösenord")]
        [Display(Name = "Lösenord")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsLoggedIn { get; set; }

    }
}
