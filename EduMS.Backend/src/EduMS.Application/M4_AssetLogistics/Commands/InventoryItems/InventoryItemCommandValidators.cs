using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.InventoryItems;

public class CreateInventoryItemCommandValidator : AbstractValidator<CreateInventoryItemCommand>
{
    public CreateInventoryItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateInventoryItemCommandValidator : AbstractValidator<UpdateInventoryItemCommand>
{
    public UpdateInventoryItemCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteInventoryItemCommandValidator : AbstractValidator<DeleteInventoryItemCommand>
{
    public DeleteInventoryItemCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}