using Microsoft.Extensions.DependencyInjection;

namespace EduMS.Application.Common.CQRS;

public class Dispatcher(IServiceProvider serviceProvider) : IDispatcher
{
    public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
    {
        var commandType = command.GetType();
        var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResponse));
        var handler = serviceProvider.GetRequiredService(handlerType);

        var pipelineType = typeof(IPipelineBehavior<,>).MakeGenericType(commandType, typeof(TResponse));
        var behaviors = serviceProvider.GetServices(pipelineType).Cast<object>().Reverse().ToList();

        Func<Task<TResponse>> next = () =>
        {
            var method = handlerType.GetMethod(nameof(ICommandHandler<ICommand<TResponse>, TResponse>.HandleAsync))!;
            return (Task<TResponse>)method.Invoke(handler, [command, cancellationToken])!;
        };

        foreach (var behavior in behaviors)
        {
            var currentNext = next;
            var behaviorInstance = behavior;
            var method = behaviorInstance.GetType().GetMethod("HandleAsync")!;
            next = () => (Task<TResponse>)method.Invoke(behaviorInstance, [command, currentNext, cancellationToken])!;
        }

        return await next();
    }

    public async Task SendAsync(ICommand command, CancellationToken cancellationToken = default)
    {
        var commandType = command.GetType();
        var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
        var handler = serviceProvider.GetRequiredService(handlerType);

        var method = handlerType.GetMethod(nameof(ICommandHandler<ICommand>.HandleAsync))!;
        await (Task)method.Invoke(handler, [command, cancellationToken])!;
    }

    public async Task<TResponse> QueryAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var queryType = query.GetType();
        var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResponse));
        var handler = serviceProvider.GetRequiredService(handlerType);

        var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResponse>, TResponse>.HandleAsync))!;
        return await (Task<TResponse>)method.Invoke(handler, [query, cancellationToken])!;
    }
}
