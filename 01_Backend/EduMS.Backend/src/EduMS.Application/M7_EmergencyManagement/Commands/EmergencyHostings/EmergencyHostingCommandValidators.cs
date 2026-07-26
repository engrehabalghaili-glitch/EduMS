using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.EmergencyHostings;

public class CreateEmergencyHostingCommandValidator : AbstractValidator<CreateEmergencyHostingCommand>
{
    public CreateEmergencyHostingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmergencyHostingCommandValidator : AbstractValidator<UpdateEmergencyHostingCommand>
{
    public UpdateEmergencyHostingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmergencyHostingCommandValidator : AbstractValidator<DeleteEmergencyHostingCommand>
{
    public DeleteEmergencyHostingCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}