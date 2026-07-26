using EduMS.Application.M6_StatisticsReports.DTOs.ExternalComplianceReports;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.ExternalComplianceReports;

public class CalculateLiveExternalComplianceReportQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetExternalComplianceReportSnapshotQuery : IRequest<ExternalComplianceReportDto>
{
    public long Id { get; set; }
}