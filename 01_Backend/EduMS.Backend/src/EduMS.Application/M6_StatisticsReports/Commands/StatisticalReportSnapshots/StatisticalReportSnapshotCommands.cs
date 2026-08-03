using EduMS.Application.M6_StatisticsReports.DTOs.StatisticalReportSnapshots;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.StatisticalReportSnapshots;

public class CreateStatisticalReportSnapshotCommand : IRequest<long>
{
    public CreateStatisticalReportSnapshotDto Dto { get; set; } = new();
}