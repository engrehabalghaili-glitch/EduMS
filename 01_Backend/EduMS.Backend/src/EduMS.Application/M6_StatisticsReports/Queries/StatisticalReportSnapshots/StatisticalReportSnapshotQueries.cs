using EduMS.Application.M6_StatisticsReports.DTOs.StatisticalReportSnapshots;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticalReportSnapshots;

public class GetStatisticalReportSnapshotByIdQuery : IRequest<StatisticalReportSnapshotDto>
{
    public long Id { get; set; }
}

public class GetAllStatisticalReportSnapshotsQuery : IRequest<IEnumerable<StatisticalReportSnapshotDto>>
{
}