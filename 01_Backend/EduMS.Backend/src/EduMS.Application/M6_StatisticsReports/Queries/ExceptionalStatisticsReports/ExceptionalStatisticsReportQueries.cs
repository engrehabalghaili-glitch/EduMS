using EduMS.Application.M6_StatisticsReports.DTOs.ExceptionalStatisticsReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.ExceptionalStatisticsReports;

public class CalculateLiveExceptionalStatisticsReportQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetExceptionalStatisticsReportSnapshotQuery : IRequest<ExceptionalStatisticsReportDto>
{
    public long Id { get; set; }
}