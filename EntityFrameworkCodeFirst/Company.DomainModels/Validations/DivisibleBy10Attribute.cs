using System;
using System.ComponentModel.DataAnnotations;

namespace Company.DomainModels.Validations
{
    public class DivisibleBy10Attribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(Object value, ValidationContext validationContext)
        {
            double price = Convert.ToDouble(value);
            
            return price % 10 == 0 ? ValidationResult.Success : new ValidationResult(this.ErrorMessage);
        }
    }
}