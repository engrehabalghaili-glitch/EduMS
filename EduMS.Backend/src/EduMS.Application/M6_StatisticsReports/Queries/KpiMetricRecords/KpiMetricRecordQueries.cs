using EduMS.Application.M6_StatisticsReports.DTOs.KpiMetricRecords;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.KpiMetricRecords;

public class CalculateLiveKpiMetricRecordQuery : IRequest<string>
{
    // Dynamic query request, returns JSON result string without DB persistence
    public long SchoolId { get; set; }
}

public class GetKpiMetricRecordSnapshotQuery : IRequest<KpiMetricRecordDto>
{
    // Returns the persisted workflow snapshot
    public long Id { get; set; }
}