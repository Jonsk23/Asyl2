using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class ApplicationsOnJobVM
    {
        public int TalentId { get; set; }
        public string Name { get; set; }
        public string CoverLetter { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsInPrimarySchool { get; set; }
        public int YearsInSecondarySchool { get; set; }
        public string WorkExperience { get; set; }
        public string SpeaksSwedish { get; set; }
        public string SpeaksEnglish { get; set; }
        public string DrivingLicense { get; set; }

    }
}
