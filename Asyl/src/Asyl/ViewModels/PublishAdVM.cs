using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class PublishAdVM
    {
        public int JobAdId { get; set; }
        public string Description { get; set; }
        public string FieldOfWork { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebPage { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int DurationInWeeks { get; set; }
        public string Logo { get; set; }

    }
}
