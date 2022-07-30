using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Category
    {
        [Display(Name = "Category Id")]
        public int Id { get; set; }

        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Must not be empty")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Image { get; set; }
        public ICollection<Part> Parts { get; set; }
    }
}