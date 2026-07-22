using EduMS.Application.M4_AssetLogistics.DTOs.AssetAuditFinalApprovals;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAuditFinalApprovals;

public class CreateAssetAuditFinalApprovalCommand : IRequest<long>
{
    public CreateAssetAuditFinalApprovalDto Dto { get; set; } = new();
}

public class UpdateAssetAuditFinalApprovalCommand : IRequest<bool>
{
    public UpdateAssetAuditFinalApprovalDto Dto { get; set; } = new();
}

public class DeleteAssetAuditFinalApprovalCommand : IRequest<bool>
{
    public long Id { get; set; }
}