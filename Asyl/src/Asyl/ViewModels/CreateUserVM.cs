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
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "School experience")]
        [Range(0,12)]
        [Required]
        public int YearsInPrimarySchool { get; set; }
        [Display(Name = "Years of higher education")]
        [Required]
        [Range(0,15)]
        public int YearsInSecondarySchool { get; set; }
        [Required]
        [StringLength(420)]
        [Display(Name = "Work Experiance and/or other merits")]
        public string WorkExperience { get; set; }
        [Display(Name = "Swedish")]
        public bool SpeaksSwedish { get; set; }
        [Display(Name = "English")]
        public bool SpeaksEnglish { get; set; }
        [Display(Name = "Drivers License")]
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
