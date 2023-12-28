namespace EventApi.Application.Exceptions;
public class FluentValidationException(IReadOnlyCollection<ValidationError> errors) : Exception("Validation failed")
{
    public IReadOnlyCollection<ValidationError> Errors { get; } = errors;
}
public record ValidationError(string PropertyName, string ErrorMessage);
