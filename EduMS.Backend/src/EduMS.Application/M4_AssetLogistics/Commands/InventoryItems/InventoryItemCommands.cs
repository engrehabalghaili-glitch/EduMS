using EduMS.Application.M4_AssetLogistics.DTOs.InventoryItems;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.InventoryItems;

public class CreateInventoryItemCommand : IRequest<long>
{
    public CreateInventoryItemDto Dto { get; set; } = new();
}

public class UpdateInventoryItemCommand : IRequest<bool>
{
    public UpdateInventoryItemDto Dto { get; set; } = new();
}

public class DeleteInventoryItemCommand : IRequest<bool>
{
    public long Id { get; set; }
}