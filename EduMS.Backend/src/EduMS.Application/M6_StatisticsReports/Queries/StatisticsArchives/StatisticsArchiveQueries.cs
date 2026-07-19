using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsArchives;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticsArchives;

public class GetStatisticsArchiveByIdQuery : IRequest<StatisticsArchiveDto>
{
    public long Id { get; set; }
}

public class GetAllStatisticsArchivesQuery : IRequest<IEnumerable<StatisticsArchiveDto>>
{
}