using EduMS.Application.M4_AssetLogistics.DTOs.InventoryReconciliations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.InventoryReconciliations;

public class GetInventoryReconciliationByIdQuery : IRequest<InventoryReconciliationDto>
{
    public long Id { get; set; }
}

public class GetAllInventoryReconciliationsQuery : IRequest<IEnumerable<InventoryReconciliationDto>>
{
}