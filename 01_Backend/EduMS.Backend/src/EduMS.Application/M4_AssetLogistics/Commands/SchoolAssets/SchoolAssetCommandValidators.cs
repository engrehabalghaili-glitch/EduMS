using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.SchoolAssets;

public class CreateSchoolAssetCommandValidator : AbstractValidator<CreateSchoolAssetCommand>
{
    public CreateSchoolAssetCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolAssetCommandValidator : AbstractValidator<UpdateSchoolAssetCommand>
{
    public UpdateSchoolAssetCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolAssetCommandValidator : AbstractValidator<DeleteSchoolAssetCommand>
{
    public DeleteSchoolAssetCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}