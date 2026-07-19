using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetBudgetAllocations;

public class CreateAssetBudgetAllocationCommandValidator : AbstractValidator<CreateAssetBudgetAllocationCommand>
{
    public CreateAssetBudgetAllocationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetBudgetAllocationCommandValidator : AbstractValidator<UpdateAssetBudgetAllocationCommand>
{
    public UpdateAssetBudgetAllocationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetBudgetAllocationCommandValidator : AbstractValidator<DeleteAssetBudgetAllocationCommand>
{
    public DeleteAssetBudgetAllocationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}