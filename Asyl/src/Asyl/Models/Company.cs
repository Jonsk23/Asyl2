﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyUsername { get; set; }
        public string CorporateIdentityNumber { get; set; }
        public string ContactPerson { get; set; }
        public string CompanyWebPage { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }

        //Navigation property
        public virtual ICollection<JobAd> JobAds { get; set; }

        //kom igen company!
        //------
    }
}
