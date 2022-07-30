using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Supplier
    {
        [Display(Name = "Supplier Id")]
        public int Id { get; set; }

        [Display(Name = "Supplier Name")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Address { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Must not be empty")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Must not be empty")]
        public string ZipCode { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Phone { get; set; }

        public ICollection<Part> Parts { get; set; }
    }
}