using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.MaintenanceSpareParts;

public class CreateMaintenanceSparePartCommandValidator : AbstractValidator<CreateMaintenanceSparePartCommand>
{
    public CreateMaintenanceSparePartCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateMaintenanceSparePartCommandValidator : AbstractValidator<UpdateMaintenanceSparePartCommand>
{
    public UpdateMaintenanceSparePartCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteMaintenanceSparePartCommandValidator : AbstractValidator<DeleteMaintenanceSparePartCommand>
{
    public DeleteMaintenanceSparePartCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}