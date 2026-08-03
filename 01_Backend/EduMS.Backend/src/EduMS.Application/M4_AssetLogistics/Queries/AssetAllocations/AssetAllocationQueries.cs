using EduMS.Application.M4_AssetLogistics.DTOs.AssetAllocations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetAllocations;

public class GetAssetAllocationByIdQuery : IRequest<AssetAllocationDto>
{
    public long Id { get; set; }
}

public class GetAllAssetAllocationsQuery : IRequest<IEnumerable<AssetAllocationDto>>
{
}