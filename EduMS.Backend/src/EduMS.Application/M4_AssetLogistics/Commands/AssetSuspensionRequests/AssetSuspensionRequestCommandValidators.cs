using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetSuspensionRequests;

public class CreateAssetSuspensionRequestCommandValidator : AbstractValidator<CreateAssetSuspensionRequestCommand>
{
    public CreateAssetSuspensionRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetSuspensionRequestCommandValidator : AbstractValidator<UpdateAssetSuspensionRequestCommand>
{
    public UpdateAssetSuspensionRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetSuspensionRequestCommandValidator : AbstractValidator<DeleteAssetSuspensionRequestCommand>
{
    public DeleteAssetSuspensionRequestCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}