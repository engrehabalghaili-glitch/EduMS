using EduMS.Application.M4_AssetLogistics.DTOs.InventoryPlans;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.InventoryPlans;

public class CreateInventoryPlanCommand : IRequest<long>
{
    public CreateInventoryPlanDto Dto { get; set; } = new();
}

public class UpdateInventoryPlanCommand : IRequest<bool>
{
    public UpdateInventoryPlanDto Dto { get; set; } = new();
}

public class DeleteInventoryPlanCommand : IRequest<bool>
{
    public long Id { get; set; }
}