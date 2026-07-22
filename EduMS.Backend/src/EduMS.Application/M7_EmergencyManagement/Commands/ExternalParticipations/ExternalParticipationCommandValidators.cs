using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.ExternalParticipations;

public class CreateExternalParticipationCommandValidator : AbstractValidator<CreateExternalParticipationCommand>
{
    public CreateExternalParticipationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateExternalParticipationCommandValidator : AbstractValidator<UpdateExternalParticipationCommand>
{
    public UpdateExternalParticipationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteExternalParticipationCommandValidator : AbstractValidator<DeleteExternalParticipationCommand>
{
    public DeleteExternalParticipationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}