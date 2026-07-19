using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetMaintenanceTickets;

public class CreateAssetMaintenanceTicketCommandValidator : AbstractValidator<CreateAssetMaintenanceTicketCommand>
{
    public CreateAssetMaintenanceTicketCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetMaintenanceTicketCommandValidator : AbstractValidator<UpdateAssetMaintenanceTicketCommand>
{
    public UpdateAssetMaintenanceTicketCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetMaintenanceTicketCommandValidator : AbstractValidator<DeleteAssetMaintenanceTicketCommand>
{
    public DeleteAssetMaintenanceTicketCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}