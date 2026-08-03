using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityComparisons;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFeasibilityComparisons;

public class GetAssetFeasibilityComparisonByIdQuery : IRequest<AssetFeasibilityComparisonDto>
{
    public long Id { get; set; }
}

public class GetAllAssetFeasibilityComparisonsQuery : IRequest<IEnumerable<AssetFeasibilityComparisonDto>>
{
}