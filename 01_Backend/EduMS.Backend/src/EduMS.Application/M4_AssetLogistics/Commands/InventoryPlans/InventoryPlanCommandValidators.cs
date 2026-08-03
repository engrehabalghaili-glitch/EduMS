using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.InventoryPlans;

public class CreateInventoryPlanCommandValidator : AbstractValidator<CreateInventoryPlanCommand>
{
    public CreateInventoryPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateInventoryPlanCommandValidator : AbstractValidator<UpdateInventoryPlanCommand>
{
    public UpdateInventoryPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteInventoryPlanCommandValidator : AbstractValidator<DeleteInventoryPlanCommand>
{
    public DeleteInventoryPlanCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}