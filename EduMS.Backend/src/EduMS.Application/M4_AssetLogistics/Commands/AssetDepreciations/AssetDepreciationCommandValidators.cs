using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetDepreciations;

public class CreateAssetDepreciationCommandValidator : AbstractValidator<CreateAssetDepreciationCommand>
{
    public CreateAssetDepreciationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetDepreciationCommandValidator : AbstractValidator<UpdateAssetDepreciationCommand>
{
    public UpdateAssetDepreciationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetDepreciationCommandValidator : AbstractValidator<DeleteAssetDepreciationCommand>
{
    public DeleteAssetDepreciationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}