using EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateStatisticalReports;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.DirectorateStatisticalReports;

public class CreateDirectorateStatisticalReportCommand : IRequest<long>
{
    public CreateDirectorateStatisticalReportDto Dto { get; set; } = new();
}

public class UpdateDirectorateStatisticalReportCommand : IRequest<bool>
{
    public UpdateDirectorateStatisticalReportDto Dto { get; set; } = new();
}

public class DeleteDirectorateStatisticalReportCommand : IRequest<bool>
{
    public long Id { get; set; }
}