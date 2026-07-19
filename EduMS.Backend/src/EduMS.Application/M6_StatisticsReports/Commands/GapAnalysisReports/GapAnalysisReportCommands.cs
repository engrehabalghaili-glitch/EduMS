using EduMS.Application.M6_StatisticsReports.DTOs.GapAnalysisReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.GapAnalysisReports;

public class DraftGapAnalysisReportCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveGapAnalysisReportCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}