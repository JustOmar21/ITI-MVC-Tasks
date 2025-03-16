using Day_06.Models;
using System.ComponentModel.DataAnnotations;

namespace Day_06.CustomValidation
{
    public class UniqueEmailAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value ,ValidationContext validationContext)
        {
            if(value is string email)
            {
                email = email.Trim();
                var context = validationContext.GetService<StoreContext>();

                ErrorMessage = $"";
                var instance = validationContext.ObjectInstance as Customer;
                var result = !context.Customers.Any(c => c.Email == email && c.ID != instance.ID) ;
                return result ? ValidationResult.Success : new ValidationResult($"Email - {email} - is already taken");
            }
            else
            {
                return new ValidationResult("Value is not String");
            }
        }
    }
}
