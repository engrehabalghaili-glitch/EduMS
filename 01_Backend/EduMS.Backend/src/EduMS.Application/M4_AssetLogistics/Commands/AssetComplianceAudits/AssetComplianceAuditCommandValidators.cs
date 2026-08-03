using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetComplianceAudits;

public class CreateAssetComplianceAuditCommandValidator : AbstractValidator<CreateAssetComplianceAuditCommand>
{
    public CreateAssetComplianceAuditCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetComplianceAuditCommandValidator : AbstractValidator<UpdateAssetComplianceAuditCommand>
{
    public UpdateAssetComplianceAuditCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetComplianceAuditCommandValidator : AbstractValidator<DeleteAssetComplianceAuditCommand>
{
    public DeleteAssetComplianceAuditCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}