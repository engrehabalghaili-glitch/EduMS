using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAssessments;

public class CreateStudentAssessmentCommandValidator : AbstractValidator<CreateStudentAssessmentCommand>
{
    public CreateStudentAssessmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAssessmentCommandValidator : AbstractValidator<UpdateStudentAssessmentCommand>
{
    public UpdateStudentAssessmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAssessmentCommandValidator : AbstractValidator<DeleteStudentAssessmentCommand>
{
    public DeleteStudentAssessmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}