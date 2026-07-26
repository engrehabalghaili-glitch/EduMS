using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExitClearances;

public class CreateStudentExitClearanceCommandValidator : AbstractValidator<CreateStudentExitClearanceCommand>
{
    public CreateStudentExitClearanceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentExitClearanceCommandValidator : AbstractValidator<UpdateStudentExitClearanceCommand>
{
    public UpdateStudentExitClearanceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentExitClearanceCommandValidator : AbstractValidator<DeleteStudentExitClearanceCommand>
{
    public DeleteStudentExitClearanceCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}