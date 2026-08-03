using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassroomOperationalRules;

public class CreateClassroomOperationalRuleCommandValidator : AbstractValidator<CreateClassroomOperationalRuleCommand>
{
    public CreateClassroomOperationalRuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateClassroomOperationalRuleCommandValidator : AbstractValidator<UpdateClassroomOperationalRuleCommand>
{
    public UpdateClassroomOperationalRuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteClassroomOperationalRuleCommandValidator : AbstractValidator<DeleteClassroomOperationalRuleCommand>
{
    public DeleteClassroomOperationalRuleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}