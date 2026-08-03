using EduMS.Application.M6_StatisticsReports.DTOs.ExceptionalStatisticsReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.ExceptionalStatisticsReports;

public class DraftExceptionalStatisticsReportCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveExceptionalStatisticsReportCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}