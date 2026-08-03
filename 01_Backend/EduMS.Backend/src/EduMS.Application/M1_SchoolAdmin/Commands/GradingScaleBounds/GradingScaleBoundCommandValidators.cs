using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.GradingScaleBounds;

public class CreateGradingScaleBoundCommandValidator : AbstractValidator<CreateGradingScaleBoundCommand>
{
    public CreateGradingScaleBoundCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateGradingScaleBoundCommandValidator : AbstractValidator<UpdateGradingScaleBoundCommand>
{
    public UpdateGradingScaleBoundCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteGradingScaleBoundCommandValidator : AbstractValidator<DeleteGradingScaleBoundCommand>
{
    public DeleteGradingScaleBoundCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}