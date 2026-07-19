using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.InventoryReconciliations;

public class CreateInventoryReconciliationCommandValidator : AbstractValidator<CreateInventoryReconciliationCommand>
{
    public CreateInventoryReconciliationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateInventoryReconciliationCommandValidator : AbstractValidator<UpdateInventoryReconciliationCommand>
{
    public UpdateInventoryReconciliationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteInventoryReconciliationCommandValidator : AbstractValidator<DeleteInventoryReconciliationCommand>
{
    public DeleteInventoryReconciliationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}