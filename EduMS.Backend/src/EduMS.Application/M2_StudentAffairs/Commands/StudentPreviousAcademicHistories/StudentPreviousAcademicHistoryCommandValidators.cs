using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentPreviousAcademicHistories;

public class CreateStudentPreviousAcademicHistoryCommandValidator : AbstractValidator<CreateStudentPreviousAcademicHistoryCommand>
{
    public CreateStudentPreviousAcademicHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentPreviousAcademicHistoryCommandValidator : AbstractValidator<UpdateStudentPreviousAcademicHistoryCommand>
{
    public UpdateStudentPreviousAcademicHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentPreviousAcademicHistoryCommandValidator : AbstractValidator<DeleteStudentPreviousAcademicHistoryCommand>
{
    public DeleteStudentPreviousAcademicHistoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}