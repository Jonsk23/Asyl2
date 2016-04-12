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
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Corporate Identity Number")]

        public string CorporateIdentityNumber { get; set; }
        [Display(Name = "Contact Person")]

        public string ContactPerson { get; set; }
        [Display(Name = "Website")]

        public string CompanyWebPage { get; set; }
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "E-mail format is invalid")]
        [Required]
        public string Email { get; set; }
        //public string CompanyName { get; set; }
    }
}
