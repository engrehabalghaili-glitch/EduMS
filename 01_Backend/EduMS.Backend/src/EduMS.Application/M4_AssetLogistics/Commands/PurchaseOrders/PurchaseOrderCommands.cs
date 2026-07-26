using EduMS.Application.M4_AssetLogistics.DTOs.PurchaseOrders;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.PurchaseOrders;

public class CreatePurchaseOrderCommand : IRequest<long>
{
    public CreatePurchaseOrderDto Dto { get; set; } = new();
}

public class UpdatePurchaseOrderCommand : IRequest<bool>
{
    public UpdatePurchaseOrderDto Dto { get; set; } = new();
}

public class DeletePurchaseOrderCommand : IRequest<bool>
{
    public long Id { get; set; }
}