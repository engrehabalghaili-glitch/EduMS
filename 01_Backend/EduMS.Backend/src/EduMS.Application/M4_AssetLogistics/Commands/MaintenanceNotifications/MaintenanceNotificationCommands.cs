using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceNotifications;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.MaintenanceNotifications;

public class CreateMaintenanceNotificationCommand : IRequest<long>
{
    public CreateMaintenanceNotificationDto Dto { get; set; } = new();
}

public class UpdateMaintenanceNotificationCommand : IRequest<bool>
{
    public UpdateMaintenanceNotificationDto Dto { get; set; } = new();
}

public class DeleteMaintenanceNotificationCommand : IRequest<bool>
{
    public long Id { get; set; }
}