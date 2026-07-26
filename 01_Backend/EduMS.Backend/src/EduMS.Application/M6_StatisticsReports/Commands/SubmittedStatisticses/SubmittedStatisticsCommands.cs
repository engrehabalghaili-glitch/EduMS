using EduMS.Application.M6_StatisticsReports.DTOs.SubmittedStatisticses;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.SubmittedStatisticses;

public class CreateSubmittedStatisticsCommand : IRequest<long>
{
    public CreateSubmittedStatisticsDto Dto { get; set; } = new();
}