using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAdmissionApplications;

public class CreateStudentAdmissionApplicationCommandValidator : AbstractValidator<CreateStudentAdmissionApplicationCommand>
{
    public CreateStudentAdmissionApplicationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAdmissionApplicationCommandValidator : AbstractValidator<UpdateStudentAdmissionApplicationCommand>
{
    public UpdateStudentAdmissionApplicationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAdmissionApplicationCommandValidator : AbstractValidator<DeleteStudentAdmissionApplicationCommand>
{
    public DeleteStudentAdmissionApplicationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}