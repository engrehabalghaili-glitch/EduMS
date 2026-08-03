using EduMS.Application.M4_AssetLogistics.DTOs.InventoryPlans;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.InventoryPlans;

public class GetInventoryPlanByIdQuery : IRequest<InventoryPlanDto>
{
    public long Id { get; set; }
}

public class GetAllInventoryPlansQuery : IRequest<IEnumerable<InventoryPlanDto>>
{
}