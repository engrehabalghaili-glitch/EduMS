using EduMS.Application.M4_AssetLogistics.DTOs.AssetAuditFinalApprovals;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetAuditFinalApprovals;

public class GetAssetAuditFinalApprovalByIdQuery : IRequest<AssetAuditFinalApprovalDto>
{
    public long Id { get; set; }
}

public class GetAllAssetAuditFinalApprovalsQuery : IRequest<IEnumerable<AssetAuditFinalApprovalDto>>
{
}