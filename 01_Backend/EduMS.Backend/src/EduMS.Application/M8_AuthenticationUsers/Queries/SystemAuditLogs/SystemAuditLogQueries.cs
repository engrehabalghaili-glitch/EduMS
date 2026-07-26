using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemAuditLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemAuditLogs;

public class GetSystemAuditLogByIdQuery : IRequest<SystemAuditLogDto>
{
    public long Id { get; set; }
}

public class GetAllSystemAuditLogsQuery : IRequest<IEnumerable<SystemAuditLogDto>>
{
}