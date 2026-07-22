using EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAssignments;

public class CreateAssetAssignmentCommand : IRequest<long>
{
    public CreateAssetAssignmentDto Dto { get; set; } = new();
}

public class UpdateAssetAssignmentCommand : IRequest<bool>
{
    public UpdateAssetAssignmentDto Dto { get; set; } = new();
}

public class DeleteAssetAssignmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}