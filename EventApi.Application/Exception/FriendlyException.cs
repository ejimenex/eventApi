using FluentValidation.Results;

namespace EventApi.Application.Exceptions
{
    public class FriendlyException : Exception
    {
        public List<string> ValidationErrors { get; set; }
        public FriendlyException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
            throw new Exception(string.Join(" | ", ValidationErrors));
        }
    }
}