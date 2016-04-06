using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class MyApplicationsVM
    {
        public int JobAdId { get; set; }
        public string CoverLetter { get; set; }
        public string Title { get; set; }
        public int LocationId { get; set; }
        public int DurationInWeeks { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string FieldOfWork { get; set; }
    }
}
