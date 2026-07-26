using EduMS.Application.M6_StatisticsReports.DTOs.KpiMetricRecords;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.KpiMetricRecords;

public class DraftKpiMetricRecordCommand : IRequest<long>
{
    // Trigger dynamic query and save draft
    public long SchoolId { get; set; }
}

public class ApproveKpiMetricRecordCommand : IRequest<bool>
{
    // Locks the draft and sets approved state
    public long Id { get; set; }
    public long ApprovedByUserId { get; set; }
}