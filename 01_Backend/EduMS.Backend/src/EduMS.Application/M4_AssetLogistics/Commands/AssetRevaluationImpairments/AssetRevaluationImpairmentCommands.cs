using EduMS.Application.M4_AssetLogistics.DTOs.AssetRevaluationImpairments;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetRevaluationImpairments;

public class CreateAssetRevaluationImpairmentCommand : IRequest<long>
{
    public CreateAssetRevaluationImpairmentDto Dto { get; set; } = new();
}

public class UpdateAssetRevaluationImpairmentCommand : IRequest<bool>
{
    public UpdateAssetRevaluationImpairmentDto Dto { get; set; } = new();
}

public class DeleteAssetRevaluationImpairmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}