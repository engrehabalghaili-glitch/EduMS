using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAbsenceExcusals;

public class CreateStudentAbsenceExcusalCommandValidator : AbstractValidator<CreateStudentAbsenceExcusalCommand>
{
    public CreateStudentAbsenceExcusalCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAbsenceExcusalCommandValidator : AbstractValidator<UpdateStudentAbsenceExcusalCommand>
{
    public UpdateStudentAbsenceExcusalCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAbsenceExcusalCommandValidator : AbstractValidator<DeleteStudentAbsenceExcusalCommand>
{
    public DeleteStudentAbsenceExcusalCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}