using System.ComponentModel.DataAnnotations;
using TaskApiV1.Models.DTO;
using TaskApiV1.Models.Properties;

namespace TaskApiV1.CustomValidations
{
    public class EstimatedDateValidation : ValidationAttribute
    {
       protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
       {
            Type t = validationContext.ObjectType;
            bool Isfrmenabledobject = false;
            DateTime dte = DateTime.Now;

            if (t == typeof(TestTodoAppFormat)) {
                 var todo = validationContext.ObjectInstance as TestTodoAppFormat;
                 dte = todo.EstimatedCompletedOn;
                 Isfrmenabledobject = true;
            }

            if (t == typeof(TodoTestcreate))
            {
                var todo = validationContext.ObjectInstance as TodoTestcreate;
                dte = todo.EstimatedCompletedOn;
                Isfrmenabledobject = true;
            }

            if (t == typeof(TodoTestUpdate))
            {
                var todo = validationContext.ObjectInstance as TodoTestUpdate;
                dte = todo.EstimatedCompletedOn;
                Isfrmenabledobject = true;
            }

            if (Isfrmenabledobject)
            {
               var lastCompletionDate = DateTime.Now.Date.AddDays(20);
                if (dte.Date < DateTime.Today.Date)
                    return new ValidationResult(errorMessage: $"Estimate Completion date should not be previous date it should between {DateTime.Today.Date} and {lastCompletionDate}");
                else if (dte.Date > lastCompletionDate)
                    return new ValidationResult(errorMessage: $"Estimate Completion date should between {DateTime.Today.Date} and {lastCompletionDate}");
                else
                    return ValidationResult.Success;
            }
            return ValidationResult.Success;
        }
    }
}
