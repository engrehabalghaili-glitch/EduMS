using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.Guardians;

public class CreateGuardianCommandValidator : AbstractValidator<CreateGuardianCommand>
{
    public CreateGuardianCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateGuardianCommandValidator : AbstractValidator<UpdateGuardianCommand>
{
    public UpdateGuardianCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteGuardianCommandValidator : AbstractValidator<DeleteGuardianCommand>
{
    public DeleteGuardianCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}