using EduMS.Application.M6_StatisticsReports.DTOs.TrendAnalysisResults;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.TrendAnalysisResults;

public class CalculateLiveTrendAnalysisResultQuery : IRequest<string>
{
    // Dynamic query request, returns JSON result string without DB persistence
    public long SchoolId { get; set; }
}

public class GetTrendAnalysisResultSnapshotQuery : IRequest<TrendAnalysisResultDto>
{
    // Returns the persisted workflow snapshot
    public long Id { get; set; }
}