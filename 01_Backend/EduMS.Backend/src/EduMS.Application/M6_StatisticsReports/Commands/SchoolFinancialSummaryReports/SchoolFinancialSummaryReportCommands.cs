using EduMS.Application.M6_StatisticsReports.DTOs.SchoolFinancialSummaryReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.SchoolFinancialSummaryReports;

public class DraftSchoolFinancialSummaryReportCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveSchoolFinancialSummaryReportCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}