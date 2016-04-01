using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyl.Models
{
    public class JobAd
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FieldOfWork { get; set; }
        public int CompanyId { get; set; }

        //Navigation property
        public virtual ICollection<Application> Applications { get; set; }

    }
}
