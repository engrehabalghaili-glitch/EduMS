using EduMS.Application.M4_AssetLogistics.DTOs.AssetAllocations;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAllocations;

public class CreateAssetAllocationCommand : IRequest<long>
{
    public CreateAssetAllocationDto Dto { get; set; } = new();
}

public class UpdateAssetAllocationCommand : IRequest<bool>
{
    public UpdateAssetAllocationDto Dto { get; set; } = new();
}

public class DeleteAssetAllocationCommand : IRequest<bool>
{
    public long Id { get; set; }
}