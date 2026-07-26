using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExtracurricularAchievements;

public class CreateStudentExtracurricularAchievementCommandValidator : AbstractValidator<CreateStudentExtracurricularAchievementCommand>
{
    public CreateStudentExtracurricularAchievementCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentExtracurricularAchievementCommandValidator : AbstractValidator<UpdateStudentExtracurricularAchievementCommand>
{
    public UpdateStudentExtracurricularAchievementCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentExtracurricularAchievementCommandValidator : AbstractValidator<DeleteStudentExtracurricularAchievementCommand>
{
    public DeleteStudentExtracurricularAchievementCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}