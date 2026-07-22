using EduMS.Application.M4_AssetLogistics.DTOs.AssetStatusRecords;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetStatusRecords;

public class GetAssetStatusRecordByIdQuery : IRequest<AssetStatusRecordDto>
{
    public long Id { get; set; }
}

public class GetAllAssetStatusRecordsQuery : IRequest<IEnumerable<AssetStatusRecordDto>>
{
}