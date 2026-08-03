using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentPermissionAuditLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.StudentPermissionAuditLogs;

public class GetStudentPermissionAuditLogByIdQuery : IRequest<StudentPermissionAuditLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentPermissionAuditLogsQuery : IRequest<IEnumerable<StudentPermissionAuditLogDto>>
{
}