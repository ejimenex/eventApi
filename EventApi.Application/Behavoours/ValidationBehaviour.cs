using EventApi.Application.Exceptions;
using FluentValidation;
using MediatR;

namespace EventApi.Application.Behavoours;
public class ValidationBehavior<TRequest, TResult>(IEnumerable<IValidator<TRequest>> validators) :
 IPipelineBehavior<TRequest, TResult> where TRequest : IRequest<TResult>
{
    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Select(failure => new ValidationError(
                    failure.PropertyName,
                    failure.ErrorMessage))
                .ToList();

            if (failures.Count != 0)
                throw new FluentValidationException(failures);
        }

        return await next();
    }
}
