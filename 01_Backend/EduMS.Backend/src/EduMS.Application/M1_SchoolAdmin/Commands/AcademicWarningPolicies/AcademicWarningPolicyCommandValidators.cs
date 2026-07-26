using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.AcademicWarningPolicies;

public class CreateAcademicWarningPolicyCommandValidator : AbstractValidator<CreateAcademicWarningPolicyCommand>
{
    public CreateAcademicWarningPolicyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAcademicWarningPolicyCommandValidator : AbstractValidator<UpdateAcademicWarningPolicyCommand>
{
    public UpdateAcademicWarningPolicyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAcademicWarningPolicyCommandValidator : AbstractValidator<DeleteAcademicWarningPolicyCommand>
{
    public DeleteAcademicWarningPolicyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}