namespace EduMS.Application.Common.CQRS;

public interface ICommandHandler<in TCommand, TResponse> : MediatR.IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken);

    Task<TResponse> MediatR.IRequestHandler<TCommand, TResponse>.Handle(TCommand request, CancellationToken cancellationToken)
        => HandleAsync(request, cancellationToken);
}

public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> 
    where TCommand : ICommand
{
}

