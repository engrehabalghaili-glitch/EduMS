using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.PreventiveMaintenanceSchedules;

public class CreatePreventiveMaintenanceScheduleCommandValidator : AbstractValidator<CreatePreventiveMaintenanceScheduleCommand>
{
    public CreatePreventiveMaintenanceScheduleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePreventiveMaintenanceScheduleCommandValidator : AbstractValidator<UpdatePreventiveMaintenanceScheduleCommand>
{
    public UpdatePreventiveMaintenanceScheduleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePreventiveMaintenanceScheduleCommandValidator : AbstractValidator<DeletePreventiveMaintenanceScheduleCommand>
{
    public DeletePreventiveMaintenanceScheduleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}