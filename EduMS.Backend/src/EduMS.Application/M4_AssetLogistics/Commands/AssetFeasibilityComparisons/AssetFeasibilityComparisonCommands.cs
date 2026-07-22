using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityComparisons;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityComparisons;

public class CreateAssetFeasibilityComparisonCommand : IRequest<long>
{
    public CreateAssetFeasibilityComparisonDto Dto { get; set; } = new();
}

public class UpdateAssetFeasibilityComparisonCommand : IRequest<bool>
{
    public UpdateAssetFeasibilityComparisonDto Dto { get; set; } = new();
}

public class DeleteAssetFeasibilityComparisonCommand : IRequest<bool>
{
    public long Id { get; set; }
}