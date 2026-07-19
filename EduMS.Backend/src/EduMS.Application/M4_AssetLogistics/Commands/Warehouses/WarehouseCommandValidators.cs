using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.Warehouses;

public class CreateWarehouseCommandValidator : AbstractValidator<CreateWarehouseCommand>
{
    public CreateWarehouseCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateWarehouseCommandValidator : AbstractValidator<UpdateWarehouseCommand>
{
    public UpdateWarehouseCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteWarehouseCommandValidator : AbstractValidator<DeleteWarehouseCommand>
{
    public DeleteWarehouseCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}