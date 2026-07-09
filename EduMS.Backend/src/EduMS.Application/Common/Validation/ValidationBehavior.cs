using EduMS.Application.Common.CQRS;

namespace EduMS.Application.Common.Validation;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> HandleAsync(
        TRequest request, 
        Func<Task<TResponse>> next, 
        CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            foreach (var validator in validators)
            {
                await validator.ValidateAsync(request, cancellationToken);
            }
        }
        return await next();
    }
}
