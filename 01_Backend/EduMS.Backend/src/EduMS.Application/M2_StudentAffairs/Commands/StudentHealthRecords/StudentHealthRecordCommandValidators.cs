using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentHealthRecords;

public class CreateStudentHealthRecordCommandValidator : AbstractValidator<CreateStudentHealthRecordCommand>
{
    public CreateStudentHealthRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentHealthRecordCommandValidator : AbstractValidator<UpdateStudentHealthRecordCommand>
{
    public UpdateStudentHealthRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentHealthRecordCommandValidator : AbstractValidator<DeleteStudentHealthRecordCommand>
{
    public DeleteStudentHealthRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}