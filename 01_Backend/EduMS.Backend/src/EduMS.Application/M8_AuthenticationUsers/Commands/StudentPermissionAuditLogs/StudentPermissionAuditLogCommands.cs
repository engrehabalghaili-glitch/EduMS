using EduMS.Application.M8_AuthenticationUsers.DTOs.StudentPermissionAuditLogs;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentPermissionAuditLogs;

public class CreateStudentPermissionAuditLogCommand : IRequest<long>
{
    public CreateStudentPermissionAuditLogDto Dto { get; set; } = new();
}

public class UpdateStudentPermissionAuditLogCommand : IRequest<bool>
{
    public UpdateStudentPermissionAuditLogDto Dto { get; set; } = new();
}

public class DeleteStudentPermissionAuditLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}