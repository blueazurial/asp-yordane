using DAL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Validators
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        public UniqueEmailAttribute(string errorMessage = "Email already in use")
        {
            ErrorMessage = errorMessage;
        }
        public override bool IsValid(object value)
        {
            UserService service = new UserService();
            return service.GetAll().SingleOrDefault(u => u.Email == (string)value) == null;
        }
    }
}