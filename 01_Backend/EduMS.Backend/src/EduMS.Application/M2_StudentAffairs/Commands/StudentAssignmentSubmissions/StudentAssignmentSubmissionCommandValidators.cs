using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAssignmentSubmissions;

public class CreateStudentAssignmentSubmissionCommandValidator : AbstractValidator<CreateStudentAssignmentSubmissionCommand>
{
    public CreateStudentAssignmentSubmissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAssignmentSubmissionCommandValidator : AbstractValidator<UpdateStudentAssignmentSubmissionCommand>
{
    public UpdateStudentAssignmentSubmissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAssignmentSubmissionCommandValidator : AbstractValidator<DeleteStudentAssignmentSubmissionCommand>
{
    public DeleteStudentAssignmentSubmissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}