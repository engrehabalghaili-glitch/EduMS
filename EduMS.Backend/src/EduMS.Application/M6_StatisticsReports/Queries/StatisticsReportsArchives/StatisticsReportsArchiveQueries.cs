using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsReportsArchives;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticsReportsArchives;

public class GetStatisticsReportsArchiveByIdQuery : IRequest<StatisticsReportsArchiveDto>
{
    public long Id { get; set; }
}

public class GetAllStatisticsReportsArchivesQuery : IRequest<IEnumerable<StatisticsReportsArchiveDto>>
{
}