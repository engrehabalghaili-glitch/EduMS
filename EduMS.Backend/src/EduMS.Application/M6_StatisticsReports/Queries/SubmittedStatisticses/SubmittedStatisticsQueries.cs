using EduMS.Application.M6_StatisticsReports.DTOs.SubmittedStatisticses;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M6_StatisticsReports.Queries.SubmittedStatisticses;

public class GetSubmittedStatisticsByIdQuery : IRequest<SubmittedStatisticsDto>
{
    public long Id { get; set; }
}

public class GetAllSubmittedStatisticsesQuery : IRequest<IEnumerable<SubmittedStatisticsDto>>
{
}