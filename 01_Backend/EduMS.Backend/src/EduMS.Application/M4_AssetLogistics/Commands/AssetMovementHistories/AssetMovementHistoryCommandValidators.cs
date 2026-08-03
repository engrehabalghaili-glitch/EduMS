using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetMovementHistories;

public class CreateAssetMovementHistoryCommandValidator : AbstractValidator<CreateAssetMovementHistoryCommand>
{
    public CreateAssetMovementHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetMovementHistoryCommandValidator : AbstractValidator<UpdateAssetMovementHistoryCommand>
{
    public UpdateAssetMovementHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetMovementHistoryCommandValidator : AbstractValidator<DeleteAssetMovementHistoryCommand>
{
    public DeleteAssetMovementHistoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}