using EduMS.Application.M6_StatisticsReports.DTOs.ComparativeReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.ComparativeReports;

public class DraftComparativeReportCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveComparativeReportCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}