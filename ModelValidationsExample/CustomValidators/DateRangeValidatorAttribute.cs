using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.Models;

public class DateRangeValidatorAttribute : ValidationAttribute
{
    public string OtherPropertyName { get; set; }

    public DateRangeValidatorAttribute()
    {
    }

    public DateRangeValidatorAttribute(string otherPropertyName)
    {
        OtherPropertyName = otherPropertyName;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            //get toDate
            DateTime? ToDate = Convert.ToDateTime(value);
            //get fromDate
            PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(OtherPropertyName);

            if (otherProperty != null)
            {
                DateTime from_date = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                if (from_date > ToDate)
                {
                    //Error message appear twice since we are providing 2 properties that generate error
                    return new ValidationResult(ErrorMessage,
                        new string[] { OtherPropertyName, validationContext.MemberName });
                }
                else
                {
                    return ValidationResult.Success;
                }
            }

            return null;
        }

        return null;
    }
}