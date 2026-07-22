using EduMS.Application.M4_AssetLogistics.DTOs.MaintenanceSpareParts;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.MaintenanceSpareParts;

public class CreateMaintenanceSparePartCommand : IRequest<long>
{
    public CreateMaintenanceSparePartDto Dto { get; set; } = new();
}

public class UpdateMaintenanceSparePartCommand : IRequest<bool>
{
    public UpdateMaintenanceSparePartDto Dto { get; set; } = new();
}

public class DeleteMaintenanceSparePartCommand : IRequest<bool>
{
    public long Id { get; set; }
}