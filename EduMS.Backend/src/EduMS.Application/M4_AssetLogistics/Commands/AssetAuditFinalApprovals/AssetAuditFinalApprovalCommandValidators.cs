using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAuditFinalApprovals;

public class CreateAssetAuditFinalApprovalCommandValidator : AbstractValidator<CreateAssetAuditFinalApprovalCommand>
{
    public CreateAssetAuditFinalApprovalCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetAuditFinalApprovalCommandValidator : AbstractValidator<UpdateAssetAuditFinalApprovalCommand>
{
    public UpdateAssetAuditFinalApprovalCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetAuditFinalApprovalCommandValidator : AbstractValidator<DeleteAssetAuditFinalApprovalCommand>
{
    public DeleteAssetAuditFinalApprovalCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}