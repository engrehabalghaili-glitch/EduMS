using EduMS.Application.M6_StatisticsReports.DTOs.TrendAnalysisResults;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.TrendAnalysisResults;

public class DraftTrendAnalysisResultCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveTrendAnalysisResultCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}