using EduMS.Application.M4_AssetLogistics.DTOs.AssetRevaluationImpairments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetRevaluationImpairments;

public class GetAssetRevaluationImpairmentByIdQuery : IRequest<AssetRevaluationImpairmentDto>
{
    public long Id { get; set; }
}

public class GetAllAssetRevaluationImpairmentsQuery : IRequest<IEnumerable<AssetRevaluationImpairmentDto>>
{
}