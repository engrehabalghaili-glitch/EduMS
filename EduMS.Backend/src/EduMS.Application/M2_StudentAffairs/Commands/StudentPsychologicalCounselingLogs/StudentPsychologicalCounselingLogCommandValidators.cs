using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentPsychologicalCounselingLogs;

public class CreateStudentPsychologicalCounselingLogCommandValidator : AbstractValidator<CreateStudentPsychologicalCounselingLogCommand>
{
    public CreateStudentPsychologicalCounselingLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentPsychologicalCounselingLogCommandValidator : AbstractValidator<UpdateStudentPsychologicalCounselingLogCommand>
{
    public UpdateStudentPsychologicalCounselingLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentPsychologicalCounselingLogCommandValidator : AbstractValidator<DeleteStudentPsychologicalCounselingLogCommand>
{
    public DeleteStudentPsychologicalCounselingLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}