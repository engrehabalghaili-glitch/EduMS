using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityComparisons;

public class CreateAssetFeasibilityComparisonCommandValidator : AbstractValidator<CreateAssetFeasibilityComparisonCommand>
{
    public CreateAssetFeasibilityComparisonCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetFeasibilityComparisonCommandValidator : AbstractValidator<UpdateAssetFeasibilityComparisonCommand>
{
    public UpdateAssetFeasibilityComparisonCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetFeasibilityComparisonCommandValidator : AbstractValidator<DeleteAssetFeasibilityComparisonCommand>
{
    public DeleteAssetFeasibilityComparisonCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}