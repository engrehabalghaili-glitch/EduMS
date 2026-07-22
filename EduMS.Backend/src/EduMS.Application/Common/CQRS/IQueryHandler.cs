namespace EduMS.Application.Common.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : MediatR.IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> HandleAsync(TQuery query, CancellationToken cancellationToken);

    Task<TResponse> MediatR.IRequestHandler<TQuery, TResponse>.Handle(TQuery request, CancellationToken cancellationToken)
        => HandleAsync(request, cancellationToken);
}

