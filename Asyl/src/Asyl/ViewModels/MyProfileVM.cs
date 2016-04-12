using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class MyProfileVM
    {
        #region My information

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ComparePassword { get; set; }

        public string Name { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail is required")]
        [EmailAddress(ErrorMessage = "E-mail format is invalid")]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "School experience")]
        [Range(0, 12)]
        public int YearsInPrimarySchool { get; set; }
        [Display(Name = "Years of higher education")]
        [Range(0, 15)]
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
        #endregion

        #region My Applications
        public int JobAdId { get; set; }
        public string CoverLetter { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int DurationInWeeks { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string FieldOfWork { get; set; }
        #endregion
    }
}
