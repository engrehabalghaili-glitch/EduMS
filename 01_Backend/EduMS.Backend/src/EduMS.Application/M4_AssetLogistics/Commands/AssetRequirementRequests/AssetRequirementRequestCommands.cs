using EduMS.Application.M4_AssetLogistics.DTOs.AssetRequirementRequests;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetRequirementRequests;

public class CreateAssetRequirementRequestCommand : IRequest<long>
{
    public CreateAssetRequirementRequestDto Dto { get; set; } = new();
}

public class UpdateAssetRequirementRequestCommand : IRequest<bool>
{
    public UpdateAssetRequirementRequestDto Dto { get; set; } = new();
}

public class DeleteAssetRequirementRequestCommand : IRequest<bool>
{
    public long Id { get; set; }
}