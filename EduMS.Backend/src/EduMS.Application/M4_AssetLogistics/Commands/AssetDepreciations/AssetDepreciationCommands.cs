using EduMS.Application.M4_AssetLogistics.DTOs.AssetDepreciations;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetDepreciations;

public class CreateAssetDepreciationCommand : IRequest<long>
{
    public CreateAssetDepreciationDto Dto { get; set; } = new();
}

public class UpdateAssetDepreciationCommand : IRequest<bool>
{
    public UpdateAssetDepreciationDto Dto { get; set; } = new();
}

public class DeleteAssetDepreciationCommand : IRequest<bool>
{
    public long Id { get; set; }
}