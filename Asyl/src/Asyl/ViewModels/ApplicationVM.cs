using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class ApplicationVM
    {
        public int JobAdId { get; set; }
        public int TalentId { get; set; }
        public string Name { get; set; }
        public string CoverLetter { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsInPrimarySchool { get; set; }
        public int YearsInSecondarySchool { get; set; }
        public string WorkExperience { get; set; }
        public bool SpeaksSwedish { get; set; }
        public bool SpeaksEnglish { get; set; }
        public bool DrivingLicense { get; set; }


    }
}
