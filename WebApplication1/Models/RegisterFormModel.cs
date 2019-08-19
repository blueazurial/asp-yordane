using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Validators;

namespace WebApplication1.Models
{
    public class RegisterFormModel
    {
        [DataType(DataType.EmailAddress)]
        [Required]
        [UniqueEmail]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage ="Password mismatch")]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        public DateTime? BirthDate { get; set; }

        public string Number { get; set; }
        [Required]
        [MaxLength(255)]
        public string Street { get; set; }
        [Required]
        [Range(1000,9999)]
        public int ZipCode { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        
        public string CondAgreement { get; set; }

    }
}