using EduMS.Application.M4_AssetLogistics.DTOs.AssetDocuments;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetDocuments;

public class CreateAssetDocumentCommand : IRequest<long>
{
    public CreateAssetDocumentDto Dto { get; set; } = new();
}

public class UpdateAssetDocumentCommand : IRequest<bool>
{
    public UpdateAssetDocumentDto Dto { get; set; } = new();
}

public class DeleteAssetDocumentCommand : IRequest<bool>
{
    public long Id { get; set; }
}