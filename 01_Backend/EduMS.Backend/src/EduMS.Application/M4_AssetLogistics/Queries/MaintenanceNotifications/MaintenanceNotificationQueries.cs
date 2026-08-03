using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceNotifications;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.MaintenanceNotifications;

public class GetMaintenanceNotificationByIdQuery : IRequest<MaintenanceNotificationDto>
{
    public long Id { get; set; }
}

public class GetAllMaintenanceNotificationsQuery : IRequest<IEnumerable<MaintenanceNotificationDto>>
{
}