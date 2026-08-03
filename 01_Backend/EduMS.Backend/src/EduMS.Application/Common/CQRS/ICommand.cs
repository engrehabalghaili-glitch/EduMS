namespace EduMS.Application.Common.CQRS;

public interface ICommand<out TResponse> : MediatR.IRequest<TResponse> { }
public interface ICommand : ICommand<Unit>, MediatR.IRequest { }

