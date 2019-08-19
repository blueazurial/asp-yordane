 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ContactFormModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        public string AuthorEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string Object { get; set; }
        [Required]
        public string Content { get; set; }
    }
}