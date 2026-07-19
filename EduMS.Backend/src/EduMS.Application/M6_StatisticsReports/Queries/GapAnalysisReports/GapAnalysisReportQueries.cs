using EduMS.Application.M6_StatisticsReports.DTOs.GapAnalysisReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.GapAnalysisReports;

public class CalculateLiveGapAnalysisReportQuery : IRequest<string>
{
    // Dynamic query request, returns JSON result string without DB persistence
    public long SchoolId { get; set; }
}

public class GetGapAnalysisReportSnapshotQuery : IRequest<GapAnalysisReportDto>
{
    // Returns the persisted workflow snapshot
    public long Id { get; set; }
}