using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.Students;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentCommandValidator : AbstractValidator<DeleteStudentCommand>
{
    public DeleteStudentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}