using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsUpdateHistories;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M6_StatisticsReports.Queries.StatisticsUpdateHistories;

public class GetStatisticsUpdateHistoryByIdQuery : IRequest<StatisticsUpdateHistoryDto>
{
    public long Id { get; set; }
}

public class GetAllStatisticsUpdateHistoriesQuery : IRequest<IEnumerable<StatisticsUpdateHistoryDto>>
{
}