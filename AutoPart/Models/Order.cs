using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Order
    {
        [Display(Name = "Order Id")]
        public int Id { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Must not be empty")]
        public int CustomerId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DefaultValue("getdate()")]
        [DataType(DataType.Date)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Must not be empty")]
        public float Amount { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}