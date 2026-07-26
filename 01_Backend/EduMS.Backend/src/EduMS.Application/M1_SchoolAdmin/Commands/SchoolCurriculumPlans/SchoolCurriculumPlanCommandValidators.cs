using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolCurriculumPlans;

public class CreateSchoolCurriculumPlanCommandValidator : AbstractValidator<CreateSchoolCurriculumPlanCommand>
{
    public CreateSchoolCurriculumPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolCurriculumPlanCommandValidator : AbstractValidator<UpdateSchoolCurriculumPlanCommand>
{
    public UpdateSchoolCurriculumPlanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolCurriculumPlanCommandValidator : AbstractValidator<DeleteSchoolCurriculumPlanCommand>
{
    public DeleteSchoolCurriculumPlanCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}