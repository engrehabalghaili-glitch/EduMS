using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.AppointmentDecisions;

public class CreateAppointmentDecisionCommandValidator : AbstractValidator<CreateAppointmentDecisionCommand>
{
    public CreateAppointmentDecisionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAppointmentDecisionCommandValidator : AbstractValidator<UpdateAppointmentDecisionCommand>
{
    public UpdateAppointmentDecisionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAppointmentDecisionCommandValidator : AbstractValidator<DeleteAppointmentDecisionCommand>
{
    public DeleteAppointmentDecisionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}