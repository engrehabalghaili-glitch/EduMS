using EduMS.Application.M8_AuthenticationUsers.DTOs.UserActivityLogs;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.UserActivityLogs;

public class CreateUserActivityLogCommand : IRequest<long>
{
    public CreateUserActivityLogDto Dto { get; set; } = new();
}

public class UpdateUserActivityLogCommand : IRequest<bool>
{
    public UpdateUserActivityLogDto Dto { get; set; } = new();
}

public class DeleteUserActivityLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}