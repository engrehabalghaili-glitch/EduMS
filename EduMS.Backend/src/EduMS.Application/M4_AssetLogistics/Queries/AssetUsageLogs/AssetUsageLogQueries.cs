using EduMS.Application.M4_AssetLogistics.DTOs.AssetUsageLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetUsageLogs;

public class GetAssetUsageLogByIdQuery : IRequest<AssetUsageLogDto>
{
    public long Id { get; set; }
}

public class GetAllAssetUsageLogsQuery : IRequest<IEnumerable<AssetUsageLogDto>>
{
}