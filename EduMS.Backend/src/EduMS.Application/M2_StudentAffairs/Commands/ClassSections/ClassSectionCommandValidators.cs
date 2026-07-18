using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.ClassSections;

public class CreateClassSectionCommandValidator : AbstractValidator<CreateClassSectionCommand>
{
    public CreateClassSectionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateClassSectionCommandValidator : AbstractValidator<UpdateClassSectionCommand>
{
    public UpdateClassSectionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteClassSectionCommandValidator : AbstractValidator<DeleteClassSectionCommand>
{
    public DeleteClassSectionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}