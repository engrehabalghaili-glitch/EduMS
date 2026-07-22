using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.UsageViolations;

public class CreateUsageViolationCommandValidator : AbstractValidator<CreateUsageViolationCommand>
{
    public CreateUsageViolationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateUsageViolationCommandValidator : AbstractValidator<UpdateUsageViolationCommand>
{
    public UpdateUsageViolationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteUsageViolationCommandValidator : AbstractValidator<DeleteUsageViolationCommand>
{
    public DeleteUsageViolationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}