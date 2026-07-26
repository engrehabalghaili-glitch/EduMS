using EduMS.Application.M6_StatisticsReports.DTOs.SystemReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.SystemReports;

public class DraftSystemReportCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveSystemReportCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}