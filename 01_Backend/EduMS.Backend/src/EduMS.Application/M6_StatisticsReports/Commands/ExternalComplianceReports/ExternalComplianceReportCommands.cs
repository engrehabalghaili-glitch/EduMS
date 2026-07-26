using EduMS.Application.M6_StatisticsReports.DTOs.ExternalComplianceReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.ExternalComplianceReports;

public class DraftExternalComplianceReportCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveExternalComplianceReportCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}