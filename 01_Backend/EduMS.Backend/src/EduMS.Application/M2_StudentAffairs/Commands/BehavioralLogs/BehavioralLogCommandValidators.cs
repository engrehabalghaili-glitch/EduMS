using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.BehavioralLogs;

public class CreateBehavioralLogCommandValidator : AbstractValidator<CreateBehavioralLogCommand>
{
    public CreateBehavioralLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateBehavioralLogCommandValidator : AbstractValidator<UpdateBehavioralLogCommand>
{
    public UpdateBehavioralLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteBehavioralLogCommandValidator : AbstractValidator<DeleteBehavioralLogCommand>
{
    public DeleteBehavioralLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}