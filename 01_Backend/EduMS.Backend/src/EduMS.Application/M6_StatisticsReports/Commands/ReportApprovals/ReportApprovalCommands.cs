using EduMS.Application.M6_StatisticsReports.DTOs.ReportApprovals;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.ReportApprovals;

public class DraftReportApprovalCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveReportApprovalCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}