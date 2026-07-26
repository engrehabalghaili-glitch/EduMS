using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.PrivilegeRules;

public class CreatePrivilegeRuleCommandValidator : AbstractValidator<CreatePrivilegeRuleCommand>
{
    public CreatePrivilegeRuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePrivilegeRuleCommandValidator : AbstractValidator<UpdatePrivilegeRuleCommand>
{
    public UpdatePrivilegeRuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePrivilegeRuleCommandValidator : AbstractValidator<DeletePrivilegeRuleCommand>
{
    public DeletePrivilegeRuleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}