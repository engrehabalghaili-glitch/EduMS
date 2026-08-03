using EduMS.Application.M6_StatisticsReports.DTOs.SchoolStatisticsDrafts;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.SchoolStatisticsDrafts;

public class DraftSchoolStatisticsDraftCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveSchoolStatisticsDraftCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}