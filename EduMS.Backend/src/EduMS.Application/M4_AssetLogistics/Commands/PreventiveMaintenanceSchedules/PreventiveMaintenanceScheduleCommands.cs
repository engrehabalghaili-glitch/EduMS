using EduMS.Application.M4_AssetLogistics.DTOs.PreventiveMaintenanceSchedules;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.PreventiveMaintenanceSchedules;

public class CreatePreventiveMaintenanceScheduleCommand : IRequest<long>
{
    public CreatePreventiveMaintenanceScheduleDto Dto { get; set; } = new();
}

public class UpdatePreventiveMaintenanceScheduleCommand : IRequest<bool>
{
    public UpdatePreventiveMaintenanceScheduleDto Dto { get; set; } = new();
}

public class DeletePreventiveMaintenanceScheduleCommand : IRequest<bool>
{
    public long Id { get; set; }
}