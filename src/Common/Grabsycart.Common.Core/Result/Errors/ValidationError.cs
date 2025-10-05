using FluentValidation.Results;

namespace Grabsycart.Common.Core.Result.Errors;

public sealed record ValidationError : Error
{
    public Dictionary<string, string[]> Errors { get;}
    
    public ValidationError(Dictionary<string, string[]> errors) : base("One or more validation errors were encountered")
    {
        Errors = errors;
    }
}

public static class ValidationHelper
{
    public static ValidationError ToValidationError(ValidationResult validationResult)
    {
        var errors = validationResult.Errors
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(f => f.ErrorMessage).ToArray()
            );

        return new (errors);
    }
}