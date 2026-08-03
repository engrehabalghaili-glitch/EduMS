using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.MaintenanceExecutions;

public class CreateMaintenanceExecutionCommandValidator : AbstractValidator<CreateMaintenanceExecutionCommand>
{
    public CreateMaintenanceExecutionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateMaintenanceExecutionCommandValidator : AbstractValidator<UpdateMaintenanceExecutionCommand>
{
    public UpdateMaintenanceExecutionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteMaintenanceExecutionCommandValidator : AbstractValidator<DeleteMaintenanceExecutionCommand>
{
    public DeleteMaintenanceExecutionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}