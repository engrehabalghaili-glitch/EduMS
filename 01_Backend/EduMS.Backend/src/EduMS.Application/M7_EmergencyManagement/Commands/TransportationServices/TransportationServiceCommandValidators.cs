using FluentValidation;

namespace EduMS.Application.M7_EmergencyManagement.Commands.TransportationServices;

public class CreateTransportationServiceCommandValidator : AbstractValidator<CreateTransportationServiceCommand>
{
    public CreateTransportationServiceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateTransportationServiceCommandValidator : AbstractValidator<UpdateTransportationServiceCommand>
{
    public UpdateTransportationServiceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteTransportationServiceCommandValidator : AbstractValidator<DeleteTransportationServiceCommand>
{
    public DeleteTransportationServiceCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}