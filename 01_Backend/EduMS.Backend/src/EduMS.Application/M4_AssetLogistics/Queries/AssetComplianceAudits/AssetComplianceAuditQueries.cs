using EduMS.Application.M4_AssetLogistics.DTOs.AssetComplianceAudits;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetComplianceAudits;

public class GetAssetComplianceAuditByIdQuery : IRequest<AssetComplianceAuditDto>
{
    public long Id { get; set; }
}

public class GetAllAssetComplianceAuditsQuery : IRequest<IEnumerable<AssetComplianceAuditDto>>
{
}