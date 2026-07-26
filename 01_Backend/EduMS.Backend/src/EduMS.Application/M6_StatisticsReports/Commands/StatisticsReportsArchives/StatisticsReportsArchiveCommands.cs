using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsReportsArchives;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticsReportsArchives;

public class CreateStatisticsReportsArchiveCommand : IRequest<long>
{
    public CreateStatisticsReportsArchiveDto Dto { get; set; } = new();
}