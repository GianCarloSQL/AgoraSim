using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ImoveisSystems.Models
{
    public class CustomValidator : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (validationContext.DisplayName)
            {
                case "Nome":
                    return new ContextDB().Owners.FirstOrDefault(x => x.Name.Equals(value.ToString())) != null ?
                        ValidationResult.Success : new ValidationResult("Este Usuario ja existe");
                case "Birth_Date":
                    DateTime data = (DateTime)value;
                    return DateTime.Now.Year - data.Year >= 18 &&
                           DateTime.Now.Year - data.Year <= 150 ?
                           ValidationResult.Success : new ValidationResult("Data Invalida.");
            }
            return ValidationResult.Success;
        }
    }
}