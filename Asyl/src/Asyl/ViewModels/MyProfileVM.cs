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

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsInPrimarySchool { get; set; }
        public int YearsInSecondarySchool { get; set; }
        public string WorkExperience { get; set; }
        public bool SpeaksSwedish { get; set; }
        public bool SpeaksEnglish { get; set; }
        public bool DrivingLicense { get; set; }
        #endregion

        #region My Applications
        public int JobAdId { get; set; }
        public string CoverLetter { get; set; }
        public string Title { get; set; }
        public int LocationId { get; set; }
        public int DurationInWeeks { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string FieldOfWork { get; set; }
        #endregion
    }
}
