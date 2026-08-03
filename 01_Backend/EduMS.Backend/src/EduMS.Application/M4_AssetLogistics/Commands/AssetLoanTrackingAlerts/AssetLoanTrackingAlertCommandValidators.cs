using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetLoanTrackingAlerts;

public class CreateAssetLoanTrackingAlertCommandValidator : AbstractValidator<CreateAssetLoanTrackingAlertCommand>
{
    public CreateAssetLoanTrackingAlertCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetLoanTrackingAlertCommandValidator : AbstractValidator<UpdateAssetLoanTrackingAlertCommand>
{
    public UpdateAssetLoanTrackingAlertCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetLoanTrackingAlertCommandValidator : AbstractValidator<DeleteAssetLoanTrackingAlertCommand>
{
    public DeleteAssetLoanTrackingAlertCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}