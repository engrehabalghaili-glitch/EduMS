using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.RemediationPlans;

public class CreateRemediationPlanCommandValidator : AbstractValidator<CreateRemediationPlanCommand>
{
    public CreateRemediationPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateRemediationPlanCommandValidator : AbstractValidator<UpdateRemediationPlanCommand>
{
    public UpdateRemediationPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteRemediationPlanCommandValidator : AbstractValidator<DeleteRemediationPlanCommand>
{
    public DeleteRemediationPlanCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}