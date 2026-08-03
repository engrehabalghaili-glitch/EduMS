using EduMS.Application.M4_AssetLogistics.DTOs.AssetInspectionLogs;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetInspectionLogs;

public class CreateAssetInspectionLogCommand : IRequest<long>
{
    public CreateAssetInspectionLogDto Dto { get; set; } = new();
}

public class UpdateAssetInspectionLogCommand : IRequest<bool>
{
    public UpdateAssetInspectionLogDto Dto { get; set; } = new();
}

public class DeleteAssetInspectionLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}