using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class Application
    {
        public int Id { get; set; }
        public int TalentId { get; set; }
        public int JobAdId { get; set; }
        public string CoverLetter { get; set; }

        public virtual Talent Talent { get; set; }
        public virtual JobAd JobAd { get; set; }

        //Commit issues
    }
}
