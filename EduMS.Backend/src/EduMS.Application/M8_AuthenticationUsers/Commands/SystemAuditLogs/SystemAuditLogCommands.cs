using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemAuditLogs;
using MediatR;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemAuditLogs;

public class CreateSystemAuditLogCommand : IRequest<long>
{
    public CreateSystemAuditLogDto Dto { get; set; } = new();
}

public class UpdateSystemAuditLogCommand : IRequest<bool>
{
    public UpdateSystemAuditLogDto Dto { get; set; } = new();
}

public class DeleteSystemAuditLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}