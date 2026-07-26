using EduMS.Application.M4_AssetLogistics.DTOs.AssetLocationRecords;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetLocationRecords;

public class CreateAssetLocationRecordCommand : IRequest<long>
{
    public CreateAssetLocationRecordDto Dto { get; set; } = new();
}

public class UpdateAssetLocationRecordCommand : IRequest<bool>
{
    public UpdateAssetLocationRecordDto Dto { get; set; } = new();
}

public class DeleteAssetLocationRecordCommand : IRequest<bool>
{
    public long Id { get; set; }
}