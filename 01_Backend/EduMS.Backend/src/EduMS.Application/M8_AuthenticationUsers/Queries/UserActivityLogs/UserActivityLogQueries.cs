using EduMS.Application.M8_AuthenticationUsers.DTOs.UserActivityLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.UserActivityLogs;

public class GetUserActivityLogByIdQuery : IRequest<UserActivityLogDto>
{
    public long Id { get; set; }
}

public class GetAllUserActivityLogsQuery : IRequest<IEnumerable<UserActivityLogDto>>
{
}