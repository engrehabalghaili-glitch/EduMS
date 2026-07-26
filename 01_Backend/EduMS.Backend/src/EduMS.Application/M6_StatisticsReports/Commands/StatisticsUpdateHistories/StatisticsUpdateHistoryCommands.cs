using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsUpdateHistories;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticsUpdateHistories;

public class CreateStatisticsUpdateHistoryCommand : IRequest<long>
{
    public CreateStatisticsUpdateHistoryDto Dto { get; set; } = new();
}