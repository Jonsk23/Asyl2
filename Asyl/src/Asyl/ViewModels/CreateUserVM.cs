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

        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string CompanyWebPage { get; set; }
        public int ContactPerson { get; set; }
        public int YearsInSecondarySchool { get; set; }
        public string WorkExperience { get; set; }
        public bool SpeaksSwedish { get; set; }
        public bool SpeaksEnglish { get; set; }
        public bool DrivingLicense { get; set; }

    }
}
