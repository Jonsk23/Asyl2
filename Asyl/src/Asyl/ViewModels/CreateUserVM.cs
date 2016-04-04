using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class CreateUserVM
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Name { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail format is invalid")]
        public string Email { get; set; }
        [Display(Name = "Phone number / #")]
        public string PhoneNumber { get; set; }
        public int YearsInPrimarySchool { get; set; }
        public int YearsInSecondarySchool { get; set; }
        public string WorkExperience { get; set; }
        public bool SpeaksSwedish { get; set; }
        public bool SpeaksEnglish { get; set; }
        public bool DrivingLicense { get; set; }
        [Required(ErrorMessage = "Please re-enter password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ComparePassword { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "You have to accept our terms and conditions")]
        public bool AcceptTerms { get; set; }

    }
}
