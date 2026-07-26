namespace EduMS.Application.Common.CQRS;

public interface IPipelineBehavior<in TRequest, TResponse> : MediatR.IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    Task<TResponse> HandleAsync(
        TRequest request, 
        Func<Task<TResponse>> next, 
        CancellationToken cancellationToken);

    async Task<TResponse> MediatR.IPipelineBehavior<TRequest, TResponse>.Handle(
        TRequest request, 
        MediatR.RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        return await HandleAsync(request, () => next(), cancellationToken);
    }
}

