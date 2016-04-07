using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.ViewModels
{
    public class MyCompanyProfileVM
    {
        #region Company information
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUsername { get; set; }
        public string CorporateIdentityNumber { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyWebPage { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        #endregion

        #region My Ads
        public int JobAdId { get; set; }
        public string Title { get; set; }
        public int ApplicationCount { get; set; }
        #endregion
    }
}
