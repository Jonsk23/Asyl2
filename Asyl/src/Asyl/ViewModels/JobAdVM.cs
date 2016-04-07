using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Asyl.ViewModels
{
    public class JobAdVM
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string FieldOfWork { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1,40)]
        public int LocationId { get; set; }
        [Required]
        [Range(1,104)]
        public int DurationInWeeks { get; set; }
    }
}
