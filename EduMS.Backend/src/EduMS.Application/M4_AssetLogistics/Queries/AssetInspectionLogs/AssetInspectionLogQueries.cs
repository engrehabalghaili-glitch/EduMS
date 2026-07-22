using EduMS.Application.M4_AssetLogistics.DTOs.AssetInspectionLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetInspectionLogs;

public class GetAssetInspectionLogByIdQuery : IRequest<AssetInspectionLogDto>
{
    public long Id { get; set; }
}

public class GetAllAssetInspectionLogsQuery : IRequest<IEnumerable<AssetInspectionLogDto>>
{
}