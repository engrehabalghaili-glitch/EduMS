using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.AccessPolicies;

public class CreateAccessPolicyCommandValidator : AbstractValidator<CreateAccessPolicyCommand>
{
    public CreateAccessPolicyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAccessPolicyCommandValidator : AbstractValidator<UpdateAccessPolicyCommand>
{
    public UpdateAccessPolicyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAccessPolicyCommandValidator : AbstractValidator<DeleteAccessPolicyCommand>
{
    public DeleteAccessPolicyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}