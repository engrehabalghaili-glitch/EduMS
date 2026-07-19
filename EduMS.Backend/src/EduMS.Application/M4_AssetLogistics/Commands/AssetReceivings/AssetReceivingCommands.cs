using EduMS.Application.M4_AssetLogistics.DTOs.AssetReceivings;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetReceivings;

public class CreateAssetReceivingCommand : IRequest<long>
{
    public CreateAssetReceivingDto Dto { get; set; } = new();
}

public class UpdateAssetReceivingCommand : IRequest<bool>
{
    public UpdateAssetReceivingDto Dto { get; set; } = new();
}

public class DeleteAssetReceivingCommand : IRequest<bool>
{
    public long Id { get; set; }
}