using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentExemptions;

public class CreateStudentExemptionCommandValidator : AbstractValidator<CreateStudentExemptionCommand>
{
    public CreateStudentExemptionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentExemptionCommandValidator : AbstractValidator<UpdateStudentExemptionCommand>
{
    public UpdateStudentExemptionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentExemptionCommandValidator : AbstractValidator<DeleteStudentExemptionCommand>
{
    public DeleteStudentExemptionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}