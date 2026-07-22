using EduMS.Application.M4_AssetLogistics.DTOs.PurchaseOrders;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.PurchaseOrders;

public class GetPurchaseOrderByIdQuery : IRequest<PurchaseOrderDto>
{
    public long Id { get; set; }
}

public class GetAllPurchaseOrdersQuery : IRequest<IEnumerable<PurchaseOrderDto>>
{
}