using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentDisciplinaryHistories;

public class CreateStudentDisciplinaryHistoryCommandValidator : AbstractValidator<CreateStudentDisciplinaryHistoryCommand>
{
    public CreateStudentDisciplinaryHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentDisciplinaryHistoryCommandValidator : AbstractValidator<UpdateStudentDisciplinaryHistoryCommand>
{
    public UpdateStudentDisciplinaryHistoryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentDisciplinaryHistoryCommandValidator : AbstractValidator<DeleteStudentDisciplinaryHistoryCommand>
{
    public DeleteStudentDisciplinaryHistoryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}