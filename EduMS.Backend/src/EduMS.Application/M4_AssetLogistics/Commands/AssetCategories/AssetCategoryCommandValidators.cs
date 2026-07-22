using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetCategories;

public class CreateAssetCategoryCommandValidator : AbstractValidator<CreateAssetCategoryCommand>
{
    public CreateAssetCategoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetCategoryCommandValidator : AbstractValidator<UpdateAssetCategoryCommand>
{
    public UpdateAssetCategoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetCategoryCommandValidator : AbstractValidator<DeleteAssetCategoryCommand>
{
    public DeleteAssetCategoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}