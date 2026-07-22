using EduMS.Application.Common.CQRS;
using FluentValidation;

namespace EduMS.Application.Common.Validation;

public class ValidationBehavior<TRequest, TResponse>(
    IEnumerable<FluentValidation.IValidator<TRequest>> fluentValidators,
    IEnumerable<EduMS.Application.Common.Validation.IValidator<TRequest>> customValidators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> HandleAsync(
        TRequest request, 
        Func<Task<TResponse>> next, 
        CancellationToken cancellationToken)
    {
        if (fluentValidators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(
                fluentValidators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults
                .Where(r => r.Errors != null)
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
        }

        if (customValidators.Any())
        {
            foreach (var validator in customValidators)
            {
                await validator.ValidateAsync(request, cancellationToken);
            }
        }

        return await next();
    }
}

