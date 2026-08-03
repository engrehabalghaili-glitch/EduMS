using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetRequirementRequests;

public class CreateAssetRequirementRequestCommandValidator : AbstractValidator<CreateAssetRequirementRequestCommand>
{
    public CreateAssetRequirementRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetRequirementRequestCommandValidator : AbstractValidator<UpdateAssetRequirementRequestCommand>
{
    public UpdateAssetRequirementRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetRequirementRequestCommandValidator : AbstractValidator<DeleteAssetRequirementRequestCommand>
{
    public DeleteAssetRequirementRequestCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}