using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceExecutions;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.MaintenanceExecutions;

public class CreateMaintenanceExecutionCommand : IRequest<long>
{
    public CreateMaintenanceExecutionDto Dto { get; set; } = new();
}

public class UpdateMaintenanceExecutionCommand : IRequest<bool>
{
    public UpdateMaintenanceExecutionDto Dto { get; set; } = new();
}

public class DeleteMaintenanceExecutionCommand : IRequest<bool>
{
    public long Id { get; set; }
}