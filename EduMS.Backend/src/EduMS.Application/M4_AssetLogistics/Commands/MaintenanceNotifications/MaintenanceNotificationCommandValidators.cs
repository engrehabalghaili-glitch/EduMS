using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.MaintenanceNotifications;

public class CreateMaintenanceNotificationCommandValidator : AbstractValidator<CreateMaintenanceNotificationCommand>
{
    public CreateMaintenanceNotificationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateMaintenanceNotificationCommandValidator : AbstractValidator<UpdateMaintenanceNotificationCommand>
{
    public UpdateMaintenanceNotificationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteMaintenanceNotificationCommandValidator : AbstractValidator<DeleteMaintenanceNotificationCommand>
{
    public DeleteMaintenanceNotificationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}