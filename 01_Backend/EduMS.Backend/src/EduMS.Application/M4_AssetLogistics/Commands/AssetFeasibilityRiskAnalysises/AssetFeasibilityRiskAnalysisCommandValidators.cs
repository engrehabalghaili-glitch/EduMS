using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetFeasibilityRiskAnalysises;

public class CreateAssetFeasibilityRiskAnalysisCommandValidator : AbstractValidator<CreateAssetFeasibilityRiskAnalysisCommand>
{
    public CreateAssetFeasibilityRiskAnalysisCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetFeasibilityRiskAnalysisCommandValidator : AbstractValidator<UpdateAssetFeasibilityRiskAnalysisCommand>
{
    public UpdateAssetFeasibilityRiskAnalysisCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetFeasibilityRiskAnalysisCommandValidator : AbstractValidator<DeleteAssetFeasibilityRiskAnalysisCommand>
{
    public DeleteAssetFeasibilityRiskAnalysisCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}