namespace EduMS.Application.Common.CQRS;

public interface ICommand<out TResponse> { }
public interface ICommand : ICommand<Unit> { }
