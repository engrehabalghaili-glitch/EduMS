using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialAuditArchives;

public class CreateAssetFinancialAuditArchiveCommandValidator : AbstractValidator<CreateAssetFinancialAuditArchiveCommand>
{
    public CreateAssetFinancialAuditArchiveCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetFinancialAuditArchiveCommandValidator : AbstractValidator<UpdateAssetFinancialAuditArchiveCommand>
{
    public UpdateAssetFinancialAuditArchiveCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetFinancialAuditArchiveCommandValidator : AbstractValidator<DeleteAssetFinancialAuditArchiveCommand>
{
    public DeleteAssetFinancialAuditArchiveCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}