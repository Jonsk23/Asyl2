using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Asyl.ViewModels
{
    public class MyCompanyProfileVM
    {
        #region Company information
        public int Id { get; set; }
        public string CompanyUsername { get; set; }



        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Corporate Identity Number")]

        public string CorporateIdentityNumber { get; set; }
        [Display(Name = "Contact Person")]

        public string ContactPerson { get; set; }
        [Display(Name = "Website")]

        public string CompanyWebPage { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        public string Logo { get; set; }
        #endregion

        //#region My Ads
        //public int JobAdId { get; set; }
        //public string Title { get; set; }
        //public int ApplicationCount { get; set; }
        //#endregion
    }
}
