using EduMS.Application.M6_StatisticsReports.DTOs.DashboardKpiConfigurations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M6_StatisticsReports.Queries.DashboardKpiConfigurations;

public class GetDashboardKpiConfigurationByIdQuery : IRequest<DashboardKpiConfigurationDto>
{
    public long Id { get; set; }
}

public class GetAllDashboardKpiConfigurationsQuery : IRequest<IEnumerable<DashboardKpiConfigurationDto>>
{
}