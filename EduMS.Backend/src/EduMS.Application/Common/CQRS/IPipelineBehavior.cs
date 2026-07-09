namespace EduMS.Application.Common.CQRS;

public interface IPipelineBehavior<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(
        TRequest request, 
        Func<Task<TResponse>> next, 
        CancellationToken cancellationToken);
}
