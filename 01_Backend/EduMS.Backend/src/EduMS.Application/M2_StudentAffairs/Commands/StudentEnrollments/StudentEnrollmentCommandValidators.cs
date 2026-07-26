using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentEnrollments;

public class CreateStudentEnrollmentCommandValidator : AbstractValidator<CreateStudentEnrollmentCommand>
{
    public CreateStudentEnrollmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentEnrollmentCommandValidator : AbstractValidator<UpdateStudentEnrollmentCommand>
{
    public UpdateStudentEnrollmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentEnrollmentCommandValidator : AbstractValidator<DeleteStudentEnrollmentCommand>
{
    public DeleteStudentEnrollmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}