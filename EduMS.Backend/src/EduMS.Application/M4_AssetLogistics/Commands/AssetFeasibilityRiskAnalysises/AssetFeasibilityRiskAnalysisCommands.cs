using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityRiskAnalysises;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityRiskAnalysises;

public class CreateAssetFeasibilityRiskAnalysisCommand : IRequest<long>
{
    public CreateAssetFeasibilityRiskAnalysisDto Dto { get; set; } = new();
}

public class UpdateAssetFeasibilityRiskAnalysisCommand : IRequest<bool>
{
    public UpdateAssetFeasibilityRiskAnalysisDto Dto { get; set; } = new();
}

public class DeleteAssetFeasibilityRiskAnalysisCommand : IRequest<bool>
{
    public long Id { get; set; }
}