using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyClosures;

public class CreateEmergencyClosureCommandValidator : AbstractValidator<CreateEmergencyClosureCommand>
{
    public CreateEmergencyClosureCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmergencyClosureCommandValidator : AbstractValidator<UpdateEmergencyClosureCommand>
{
    public UpdateEmergencyClosureCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmergencyClosureCommandValidator : AbstractValidator<DeleteEmergencyClosureCommand>
{
    public DeleteEmergencyClosureCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}