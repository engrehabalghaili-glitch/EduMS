using EduMS.Application.M4_AssetLogistics.DTOs.AssetTransferRequests;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetTransferRequests;

public class CreateAssetTransferRequestCommand : IRequest<long>
{
    public CreateAssetTransferRequestDto Dto { get; set; } = new();
}

public class UpdateAssetTransferRequestCommand : IRequest<bool>
{
    public UpdateAssetTransferRequestDto Dto { get; set; } = new();
}

public class DeleteAssetTransferRequestCommand : IRequest<bool>
{
    public long Id { get; set; }
}