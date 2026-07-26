using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyIncidents;

public class CreateEmergencyIncidentCommandValidator : AbstractValidator<CreateEmergencyIncidentCommand>
{
    public CreateEmergencyIncidentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmergencyIncidentCommandValidator : AbstractValidator<UpdateEmergencyIncidentCommand>
{
    public UpdateEmergencyIncidentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmergencyIncidentCommandValidator : AbstractValidator<DeleteEmergencyIncidentCommand>
{
    public DeleteEmergencyIncidentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}