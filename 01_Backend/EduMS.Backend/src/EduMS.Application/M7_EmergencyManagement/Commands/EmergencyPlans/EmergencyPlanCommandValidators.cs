using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyPlans;

public class CreateEmergencyPlanCommandValidator : AbstractValidator<CreateEmergencyPlanCommand>
{
    public CreateEmergencyPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmergencyPlanCommandValidator : AbstractValidator<UpdateEmergencyPlanCommand>
{
    public UpdateEmergencyPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmergencyPlanCommandValidator : AbstractValidator<DeleteEmergencyPlanCommand>
{
    public DeleteEmergencyPlanCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}