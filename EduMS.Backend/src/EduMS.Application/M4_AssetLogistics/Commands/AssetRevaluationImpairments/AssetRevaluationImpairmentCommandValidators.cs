using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetRevaluationImpairments;

public class CreateAssetRevaluationImpairmentCommandValidator : AbstractValidator<CreateAssetRevaluationImpairmentCommand>
{
    public CreateAssetRevaluationImpairmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetRevaluationImpairmentCommandValidator : AbstractValidator<UpdateAssetRevaluationImpairmentCommand>
{
    public UpdateAssetRevaluationImpairmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetRevaluationImpairmentCommandValidator : AbstractValidator<DeleteAssetRevaluationImpairmentCommand>
{
    public DeleteAssetRevaluationImpairmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}