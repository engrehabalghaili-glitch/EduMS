using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFinancialses;

public class CreateAssetFinancialsCommandValidator : AbstractValidator<CreateAssetFinancialsCommand>
{
    public CreateAssetFinancialsCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetFinancialsCommandValidator : AbstractValidator<UpdateAssetFinancialsCommand>
{
    public UpdateAssetFinancialsCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetFinancialsCommandValidator : AbstractValidator<DeleteAssetFinancialsCommand>
{
    public DeleteAssetFinancialsCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}