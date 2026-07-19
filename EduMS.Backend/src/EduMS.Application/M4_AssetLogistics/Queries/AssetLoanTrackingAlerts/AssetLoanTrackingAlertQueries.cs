using EduMS.Application.M4_AssetLogistics.DTOs.AssetLoanTrackingAlerts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetLoanTrackingAlerts;

public class GetAssetLoanTrackingAlertByIdQuery : IRequest<AssetLoanTrackingAlertDto>
{
    public long Id { get; set; }
}

public class GetAllAssetLoanTrackingAlertsQuery : IRequest<IEnumerable<AssetLoanTrackingAlertDto>>
{
}