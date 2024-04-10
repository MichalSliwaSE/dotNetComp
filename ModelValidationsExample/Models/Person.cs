using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ModelValidationsExample.Models;

public class Person // :  IValidatableObject
{
    [Required(ErrorMessage = "{0} you need to put")]
    [Display(Name = "Person Name")]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} to short bro, should be between {2} and {1} long")]

    public string? PersonName { get; set; }

    [EmailAddress(ErrorMessage = "{0} has to have @ bro")]
    public string? Email { get; set; }

    [Phone(ErrorMessage = "{0} wrong yo")]
    // [ValidateNever]
    public string? Phone { get; set; }

    // [Required(ErrorMessage = "{0} can not be blank")]
    public string? Password { get; set; }

    // [Required(ErrorMessage = "{0} can not be blank")]
    [Compare("Password", ErrorMessage = "{0} and {1} not mach dude")]
    [Display(Name = "Re-enter Password")]
    public string? RepeatPassword { get; set; }

    [Range(20.0, 1000.95, ErrorMessage = "{0} has to be between {1}$ and {2}$")]
    public double? Price { get; set; }

    // [MinimumYearValidator(2005)] //ErrorMessage = "Date of birth should be ove {0}"
    [BindNever]
    public DateTime? DateOfBirth { get; set; }

    public int? Age { get; set; }


    public DateTime? FromDate { get; set; }

    [DateRangeValidator("FromDate", ErrorMessage = "From date should be older than or equal to ToDate")]
    public DateTime? ToDate { get; set; }
    
    public List<string?> Tags { get; set; }
    public override string ToString()
    {
        return $"Person object - Person name: {PersonName}, Email: {Email}, Phone {Phone}, Password: {Password}," +
               $"RepeatPassword: {RepeatPassword}, Price: {Price}, Date of birth: {DateOfBirth}, Tags: {Tags}";
    }
    
    

    // public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    // {
    //     if (DateOfBirth.HasValue == false && Age.HasValue == false)
    //     {
    //         //yield for returning multiple results on iterator method
    //         yield return new ValidationResult("Either DOB or age should be supplied", new[] { nameof(Age) });
    //     }
    // }
}