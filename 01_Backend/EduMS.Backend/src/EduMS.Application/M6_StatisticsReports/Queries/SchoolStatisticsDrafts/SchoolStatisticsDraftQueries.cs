using EduMS.Application.M6_StatisticsReports.DTOs.SchoolStatisticsDrafts;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Queries.SchoolStatisticsDrafts;

public class CalculateLiveSchoolStatisticsDraftQuery : IRequest<string>
{
    public long SchoolId { get; set; }
}

public class GetSchoolStatisticsDraftSnapshotQuery : IRequest<SchoolStatisticsDraftDto>
{
    public long Id { get; set; }
}