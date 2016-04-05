using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class CreateCompanyVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string CompanyName { get; set; }
        public string CorporateIdentityNumber { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyWebPage { get; set; }
        public string Email { get; set; }
        //public string CompanyName { get; set; }
    }
}
