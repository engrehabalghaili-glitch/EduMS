using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAuditLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAuditLogs;

public class GetSchoolAuditLogByIdQuery : IRequest<SchoolAuditLogDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolAuditLogsQuery : IRequest<IEnumerable<SchoolAuditLogDto>>
{
}