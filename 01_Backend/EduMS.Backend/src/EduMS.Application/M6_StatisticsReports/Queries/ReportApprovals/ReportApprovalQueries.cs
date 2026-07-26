using EduMS.Application.M6_StatisticsReports.DTOs.ReportApprovals;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.ReportApprovals;

public class CalculateLiveReportApprovalQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetReportApprovalSnapshotQuery : IRequest<ReportApprovalDto>
{
    public long Id { get; set; }
}