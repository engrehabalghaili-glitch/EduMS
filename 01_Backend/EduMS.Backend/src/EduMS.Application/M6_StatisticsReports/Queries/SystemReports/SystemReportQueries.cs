using EduMS.Application.M6_StatisticsReports.DTOs.SystemReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.SystemReports;

public class CalculateLiveSystemReportQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetSystemReportSnapshotQuery : IRequest<SystemReportDto>
{
    public long Id { get; set; }
}