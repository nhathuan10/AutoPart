using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class OrderDetail
    {
        [Display(Name = "Order Detail Id")]
        public int Id { get; set; }

        [Display(Name = "Order")]
        [Required(ErrorMessage = "Must not be empty")]
        public int OrderId { get; set; }

        [Display(Name = "Part")]
        [Required(ErrorMessage = "Must not be empty")]
        public int PartId { get; set; }

        [Display(Name = "Quantity")]
        [Required(ErrorMessage = "Must not be empty")]
        public int Quantity { get; set; }

        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "Must not be empty")]
        public float UnitPrice { get; set; }
        public Order Order { get; set; }
        public Part Part { get; set; }
    }
}