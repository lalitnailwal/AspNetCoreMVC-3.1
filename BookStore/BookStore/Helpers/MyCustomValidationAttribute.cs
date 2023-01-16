using System.ComponentModel.DataAnnotations;

namespace BookStore.Helpers
{
    public class MyCustomValidationAttribute: ValidationAttribute
    {      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookName = value.ToString();

                if (bookName.Contains("MVC"))
                {
                    return ValidationResult.Success;
                }
            }
            
            return new ValidationResult("BookName does not contain the desired value");
        }
    }
}
