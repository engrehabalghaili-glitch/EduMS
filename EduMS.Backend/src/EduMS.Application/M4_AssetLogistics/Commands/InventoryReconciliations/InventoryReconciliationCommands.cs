using EduMS.Application.M4_AssetLogistics.DTOs.InventoryReconciliations;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.InventoryReconciliations;

public class CreateInventoryReconciliationCommand : IRequest<long>
{
    public CreateInventoryReconciliationDto Dto { get; set; } = new();
}

public class UpdateInventoryReconciliationCommand : IRequest<bool>
{
    public UpdateInventoryReconciliationDto Dto { get; set; } = new();
}

public class DeleteInventoryReconciliationCommand : IRequest<bool>
{
    public long Id { get; set; }
}