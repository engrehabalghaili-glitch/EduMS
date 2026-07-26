using EduMS.Application.M6_StatisticsReports.DTOs.ComparativeReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.ComparativeReports;

public class CalculateLiveComparativeReportQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetComparativeReportSnapshotQuery : IRequest<ComparativeReportDto>
{
    public long Id { get; set; }
}