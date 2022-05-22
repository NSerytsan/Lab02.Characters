using System.ComponentModel.DataAnnotations;

namespace Lab02.Characters.Models.Validators;

public class SkillIdsValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        bool isValid = false;

        if (value is not null && value is IEnumerable<int> skillIds && skillIds.Any())
        {
            isValid = true;
        }
        return (isValid) ? ValidationResult.Success : new ValidationResult("Виберіть навички");
    }
}
