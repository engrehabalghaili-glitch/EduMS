using EduMS.Application.M4_AssetLogistics.DTOs.AssetFeasibilityRiskAnalysises;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFeasibilityRiskAnalysises;

public class GetAssetFeasibilityRiskAnalysisByIdQuery : IRequest<AssetFeasibilityRiskAnalysisDto>
{
    public long Id { get; set; }
}

public class GetAllAssetFeasibilityRiskAnalysisesQuery : IRequest<IEnumerable<AssetFeasibilityRiskAnalysisDto>>
{
}