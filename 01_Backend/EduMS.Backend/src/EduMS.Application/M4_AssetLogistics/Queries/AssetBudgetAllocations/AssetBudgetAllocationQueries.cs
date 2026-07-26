using EduMS.Application.M4_AssetLogistics.DTOs.AssetBudgetAllocations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetBudgetAllocations;

public class GetAssetBudgetAllocationByIdQuery : IRequest<AssetBudgetAllocationDto>
{
    public long Id { get; set; }
}

public class GetAllAssetBudgetAllocationsQuery : IRequest<IEnumerable<AssetBudgetAllocationDto>>
{
}