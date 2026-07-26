using EduMS.Application.M6_StatisticsReports.DTOs.SchoolFinancialSummaryReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.SchoolFinancialSummaryReports;

public class CalculateLiveSchoolFinancialSummaryReportQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetSchoolFinancialSummaryReportSnapshotQuery : IRequest<SchoolFinancialSummaryReportDto>
{
    public long Id { get; set; }
}