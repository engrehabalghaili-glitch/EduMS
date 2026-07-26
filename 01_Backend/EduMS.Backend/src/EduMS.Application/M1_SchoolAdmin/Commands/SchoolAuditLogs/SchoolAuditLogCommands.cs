using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAuditLogs;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAuditLogs;

public class CreateSchoolAuditLogCommand : IRequest<long>
{
    public CreateSchoolAuditLogDto Dto { get; set; } = new();
}

public class UpdateSchoolAuditLogCommand : IRequest<bool>
{
    public UpdateSchoolAuditLogDto Dto { get; set; } = new();
}

public class DeleteSchoolAuditLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}