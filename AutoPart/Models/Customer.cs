using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Customer
    {
        [Display(Name = "Customer Id")]
        public int Id { get; set; }

        [Display(Name = "Customer Name")]
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

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Must not be empty")]
        //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Phone { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
