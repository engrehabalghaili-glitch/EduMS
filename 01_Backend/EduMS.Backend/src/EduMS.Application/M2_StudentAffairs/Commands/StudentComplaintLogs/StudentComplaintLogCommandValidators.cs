using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentComplaintLogs;

public class CreateStudentComplaintLogCommandValidator : AbstractValidator<CreateStudentComplaintLogCommand>
{
    public CreateStudentComplaintLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentComplaintLogCommandValidator : AbstractValidator<UpdateStudentComplaintLogCommand>
{
    public UpdateStudentComplaintLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentComplaintLogCommandValidator : AbstractValidator<DeleteStudentComplaintLogCommand>
{
    public DeleteStudentComplaintLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}