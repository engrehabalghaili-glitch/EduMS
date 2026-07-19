using EduMS.Application.M4_AssetLogistics.DTOs.AssetFinancialAuditArchives;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetFinancialAuditArchives;

public class GetAssetFinancialAuditArchiveByIdQuery : IRequest<AssetFinancialAuditArchiveDto>
{
    public long Id { get; set; }
}

public class GetAllAssetFinancialAuditArchivesQuery : IRequest<IEnumerable<AssetFinancialAuditArchiveDto>>
{
}