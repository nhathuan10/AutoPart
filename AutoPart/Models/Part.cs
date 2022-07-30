using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Part
    {
        [Display(Name = "Part Id")]
        public int Id { get; set; }

        [Display(Name = "Part Name")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Name { get; set; }

        [Display(Name = "Car Brand")]
        [Required(ErrorMessage = "Must not be empty")]
        public int CarBrandId { get; set; }

        [Display(Name = "Supplier")]
        [Required(ErrorMessage = "Must not be empty")]
        public int SupplierId { get; set; }

        [Display(Name = "Manufacturer")]
        [Required(ErrorMessage = "Must not be empty")]
        public int ManufacturerId { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Must not be empty")]
        public int CategoryId { get; set; }

        [Display(Name = "Car Name")]
        [Required(ErrorMessage = "Must not be empty")]
        public string CarName { get; set; }

        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "Must not be empty")]
        public float UnitPrice { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Must not be empty")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Condition")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Condition { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Image { get; set; }

        [Display(Name = "Image Sub 1")]
        [Required(ErrorMessage = "Must not be empty")]
        public string ImageSub1 { get; set; }

        [Display(Name = "Image Sub 2")]
        [Required(ErrorMessage = "Must not be empty")]
        public string ImageSub2 { get; set; }

        [Display(Name = "Quantity In Stock")]
        [Required(ErrorMessage = "Must not be empty")]
        [Range(0, 9999999, ErrorMessage = "Invalid quantity")]
        public int QuantityinStock { get; set; }
        public CarBrand CarBrand { get; set; }
        public Supplier Supplier { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}