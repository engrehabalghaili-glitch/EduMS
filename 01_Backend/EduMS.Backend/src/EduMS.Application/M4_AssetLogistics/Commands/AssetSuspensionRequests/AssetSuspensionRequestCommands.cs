using EduMS.Application.M4_AssetLogistics.DTOs.AssetSuspensionRequests;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetSuspensionRequests;

public class CreateAssetSuspensionRequestCommand : IRequest<long>
{
    public CreateAssetSuspensionRequestDto Dto { get; set; } = new();
}

public class UpdateAssetSuspensionRequestCommand : IRequest<bool>
{
    public UpdateAssetSuspensionRequestDto Dto { get; set; } = new();
}

public class DeleteAssetSuspensionRequestCommand : IRequest<bool>
{
    public long Id { get; set; }
}