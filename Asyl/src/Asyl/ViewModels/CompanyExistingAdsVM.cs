using Asyl.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class CompanyExistingAdsVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FieldOfWork { get; set; }
        public int CompanyId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int DurationInWeeks { get; set; }

        //public virtual Company Company { get; set; }
        //Navigation property
        //public virtual ICollection<Application> Applications { get; set; }
        public int ApplicationCount { get; set; }
    }
}
