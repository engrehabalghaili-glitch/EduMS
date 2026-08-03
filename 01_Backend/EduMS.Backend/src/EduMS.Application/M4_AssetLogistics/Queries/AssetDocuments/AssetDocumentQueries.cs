using EduMS.Application.M4_AssetLogistics.DTOs.AssetDocuments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetDocuments;

public class GetAssetDocumentByIdQuery : IRequest<AssetDocumentDto>
{
    public long Id { get; set; }
}

public class GetAllAssetDocumentsQuery : IRequest<IEnumerable<AssetDocumentDto>>
{
}