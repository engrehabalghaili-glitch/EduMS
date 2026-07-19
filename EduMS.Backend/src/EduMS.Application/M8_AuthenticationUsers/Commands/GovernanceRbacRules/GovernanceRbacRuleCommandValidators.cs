using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.GovernanceRbacRules;

public class CreateGovernanceRbacRuleCommandValidator : AbstractValidator<CreateGovernanceRbacRuleCommand>
{
    public CreateGovernanceRbacRuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateGovernanceRbacRuleCommandValidator : AbstractValidator<UpdateGovernanceRbacRuleCommand>
{
    public UpdateGovernanceRbacRuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteGovernanceRbacRuleCommandValidator : AbstractValidator<DeleteGovernanceRbacRuleCommand>
{
    public DeleteGovernanceRbacRuleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}