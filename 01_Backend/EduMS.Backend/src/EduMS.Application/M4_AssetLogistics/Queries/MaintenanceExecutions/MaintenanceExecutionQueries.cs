using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceExecutions;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.MaintenanceExecutions;

public class GetMaintenanceExecutionByIdQuery : IRequest<MaintenanceExecutionDto>
{
    public long Id { get; set; }
}

public class GetAllMaintenanceExecutionsQuery : IRequest<IEnumerable<MaintenanceExecutionDto>>
{
}