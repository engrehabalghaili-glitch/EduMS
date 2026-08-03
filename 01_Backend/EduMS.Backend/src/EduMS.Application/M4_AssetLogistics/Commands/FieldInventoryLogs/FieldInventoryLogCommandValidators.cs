using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.FieldInventoryLogs;

public class CreateFieldInventoryLogCommandValidator : AbstractValidator<CreateFieldInventoryLogCommand>
{
    public CreateFieldInventoryLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFieldInventoryLogCommandValidator : AbstractValidator<UpdateFieldInventoryLogCommand>
{
    public UpdateFieldInventoryLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFieldInventoryLogCommandValidator : AbstractValidator<DeleteFieldInventoryLogCommand>
{
    public DeleteFieldInventoryLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}