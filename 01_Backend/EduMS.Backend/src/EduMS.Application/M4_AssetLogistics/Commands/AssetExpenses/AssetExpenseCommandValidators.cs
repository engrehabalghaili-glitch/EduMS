using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetExpenses;

public class CreateAssetExpenseCommandValidator : AbstractValidator<CreateAssetExpenseCommand>
{
    public CreateAssetExpenseCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetExpenseCommandValidator : AbstractValidator<UpdateAssetExpenseCommand>
{
    public UpdateAssetExpenseCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetExpenseCommandValidator : AbstractValidator<DeleteAssetExpenseCommand>
{
    public DeleteAssetExpenseCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}