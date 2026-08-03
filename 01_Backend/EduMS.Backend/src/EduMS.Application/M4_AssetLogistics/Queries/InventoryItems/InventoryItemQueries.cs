using EduMS.Application.M4_AssetLogistics.DTOs.InventoryItems;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.InventoryItems;

public class GetInventoryItemByIdQuery : IRequest<InventoryItemDto>
{
    public long Id { get; set; }
}

public class GetAllInventoryItemsQuery : IRequest<IEnumerable<InventoryItemDto>>
{
}