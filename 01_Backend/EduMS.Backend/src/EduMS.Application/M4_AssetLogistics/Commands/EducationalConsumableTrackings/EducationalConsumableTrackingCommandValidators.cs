using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.EducationalConsumableTrackings;

public class CreateEducationalConsumableTrackingCommandValidator : AbstractValidator<CreateEducationalConsumableTrackingCommand>
{
    public CreateEducationalConsumableTrackingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEducationalConsumableTrackingCommandValidator : AbstractValidator<UpdateEducationalConsumableTrackingCommand>
{
    public UpdateEducationalConsumableTrackingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEducationalConsumableTrackingCommandValidator : AbstractValidator<DeleteEducationalConsumableTrackingCommand>
{
    public DeleteEducationalConsumableTrackingCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}