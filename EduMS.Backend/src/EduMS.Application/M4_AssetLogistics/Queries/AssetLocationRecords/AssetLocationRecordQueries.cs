using EduMS.Application.M4_AssetLogistics.DTOs.AssetLocationRecords;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetLocationRecords;

public class GetAssetLocationRecordByIdQuery : IRequest<AssetLocationRecordDto>
{
    public long Id { get; set; }
}

public class GetAllAssetLocationRecordsQuery : IRequest<IEnumerable<AssetLocationRecordDto>>
{
}