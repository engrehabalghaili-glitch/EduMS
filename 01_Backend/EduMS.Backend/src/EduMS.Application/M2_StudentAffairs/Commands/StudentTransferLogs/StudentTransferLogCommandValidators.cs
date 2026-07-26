using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransferLogs;

public class CreateStudentTransferLogCommandValidator : AbstractValidator<CreateStudentTransferLogCommand>
{
    public CreateStudentTransferLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentTransferLogCommandValidator : AbstractValidator<UpdateStudentTransferLogCommand>
{
    public UpdateStudentTransferLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentTransferLogCommandValidator : AbstractValidator<DeleteStudentTransferLogCommand>
{
    public DeleteStudentTransferLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}