using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class CarBrand
    {
        [Display(Name = "Car Brand Id")]
        public int Id { get; set; }

        [Display(Name = "Car Brand")]
        [Required(ErrorMessage = "Must not be empty")]
        public string CarBrandName { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Country { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}