using EduMS.Application.M4_AssetLogistics.DTOs.AssetStatusRecords;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetStatusRecords;

public class CreateAssetStatusRecordCommand : IRequest<long>
{
    public CreateAssetStatusRecordDto Dto { get; set; } = new();
}

public class UpdateAssetStatusRecordCommand : IRequest<bool>
{
    public UpdateAssetStatusRecordDto Dto { get; set; } = new();
}

public class DeleteAssetStatusRecordCommand : IRequest<bool>
{
    public long Id { get; set; }
}