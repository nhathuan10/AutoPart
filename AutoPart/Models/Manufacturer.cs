using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Manufacturer
    {
        [Display(Name = "Manufacturer Id")]
        public int Id { get; set; }

        [Display(Name = "Manufacturer Name")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Must not be empty")]
        public string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "Must not be empty")]
        public string State { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}