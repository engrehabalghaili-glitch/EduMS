using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoanTrackingAlerts;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetLoanTrackingAlerts;

public class CreateAssetLoanTrackingAlertCommand : IRequest<long>
{
    public CreateAssetLoanTrackingAlertDto Dto { get; set; } = new();
}

public class UpdateAssetLoanTrackingAlertCommand : IRequest<bool>
{
    public UpdateAssetLoanTrackingAlertDto Dto { get; set; } = new();
}

public class DeleteAssetLoanTrackingAlertCommand : IRequest<bool>
{
    public long Id { get; set; }
}