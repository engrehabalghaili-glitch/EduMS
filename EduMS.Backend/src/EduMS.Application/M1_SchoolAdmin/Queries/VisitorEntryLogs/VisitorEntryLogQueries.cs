using EduMS.Application.M1_SchoolAdmin.DTOs.VisitorEntryLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.VisitorEntryLogs;

public class GetVisitorEntryLogByIdQuery : IRequest<VisitorEntryLogDto>
{
    public long Id { get; set; }
}

public class GetAllVisitorEntryLogsQuery : IRequest<IEnumerable<VisitorEntryLogDto>>
{
}