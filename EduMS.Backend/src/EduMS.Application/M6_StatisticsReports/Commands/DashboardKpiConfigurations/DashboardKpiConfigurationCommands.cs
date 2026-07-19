using EduMS.Application.M6_StatisticsReports.DTOs.DashboardKpiConfigurations;
using MediatR;

namespace EduMS.Application.M6_StatisticsReports.Commands.DashboardKpiConfigurations;

public class CreateDashboardKpiConfigurationCommand : IRequest<long>
{
    public CreateDashboardKpiConfigurationDto Dto { get; set; } = new();
}

public class UpdateDashboardKpiConfigurationCommand : IRequest<bool>
{
    public UpdateDashboardKpiConfigurationDto Dto { get; set; } = new();
}

public class DeleteDashboardKpiConfigurationCommand : IRequest<bool>
{
    public long Id { get; set; }
}