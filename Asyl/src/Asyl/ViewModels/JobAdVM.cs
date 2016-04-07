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
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Field")]
        public string FieldOfWork { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Location")]
        public int LocationId { get; set; }
        [Required]
        [Range(1,104)]
        [Display(Name = "Duration")]
        public int DurationInWeeks { get; set; }
    }
}
