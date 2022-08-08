using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AutoPart.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Must not be empty")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Must not be empty")]
        public string Subject { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Must not be empty")]
        [DataType(DataType.MultilineText)]
        public string MessageContent { get; set; }
    }
}