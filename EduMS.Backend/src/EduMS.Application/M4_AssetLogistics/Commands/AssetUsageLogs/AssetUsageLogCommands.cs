using EduMS.Application.M4_AssetLogistics.DTOs.AssetUsageLogs;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetUsageLogs;

public class CreateAssetUsageLogCommand : IRequest<long>
{
    public CreateAssetUsageLogDto Dto { get; set; } = new();
}

public class UpdateAssetUsageLogCommand : IRequest<bool>
{
    public UpdateAssetUsageLogDto Dto { get; set; } = new();
}

public class DeleteAssetUsageLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}