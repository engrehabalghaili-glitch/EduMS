using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalStages;

public class CreateEducationalStageCommandValidator : AbstractValidator<CreateEducationalStageCommand>
{
    public CreateEducationalStageCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEducationalStageCommandValidator : AbstractValidator<UpdateEducationalStageCommand>
{
    public UpdateEducationalStageCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEducationalStageCommandValidator : AbstractValidator<DeleteEducationalStageCommand>
{
    public DeleteEducationalStageCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}