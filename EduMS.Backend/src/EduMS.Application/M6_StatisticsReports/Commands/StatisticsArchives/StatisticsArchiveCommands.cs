using EduMS.Application.M6_StatisticsReports.DTOs.StatisticsArchives;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticsArchives;

public class CreateStatisticsArchiveCommand : IRequest<long>
{
    public CreateStatisticsArchiveDto Dto { get; set; } = new();
}