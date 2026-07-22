using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentInventoryCustodies;

public class CreateStudentInventoryCustodyCommandValidator : AbstractValidator<CreateStudentInventoryCustodyCommand>
{
    public CreateStudentInventoryCustodyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentInventoryCustodyCommandValidator : AbstractValidator<UpdateStudentInventoryCustodyCommand>
{
    public UpdateStudentInventoryCustodyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentInventoryCustodyCommandValidator : AbstractValidator<DeleteStudentInventoryCustodyCommand>
{
    public DeleteStudentInventoryCustodyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}