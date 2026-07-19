using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetTechnicalSpecifications;

public class CreateAssetTechnicalSpecificationCommandValidator : AbstractValidator<CreateAssetTechnicalSpecificationCommand>
{
    public CreateAssetTechnicalSpecificationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetTechnicalSpecificationCommandValidator : AbstractValidator<UpdateAssetTechnicalSpecificationCommand>
{
    public UpdateAssetTechnicalSpecificationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetTechnicalSpecificationCommandValidator : AbstractValidator<DeleteAssetTechnicalSpecificationCommand>
{
    public DeleteAssetTechnicalSpecificationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}