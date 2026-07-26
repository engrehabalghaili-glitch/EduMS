using EduMS.Application.M4_AssetLogistics.DTOs.AssetMaintenanceTickets;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetMaintenanceTickets;

public class GetAssetMaintenanceTicketByIdQuery : IRequest<AssetMaintenanceTicketDto>
{
    public long Id { get; set; }
}

public class GetAllAssetMaintenanceTicketsQuery : IRequest<IEnumerable<AssetMaintenanceTicketDto>>
{
}