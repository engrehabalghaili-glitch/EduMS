using EduMS.Application.M4_AssetLogistics.DTOs.AssetMaintenanceTickets;
using MediatR;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetMaintenanceTickets;

public class CreateAssetMaintenanceTicketCommand : IRequest<long>
{
    public CreateAssetMaintenanceTicketDto Dto { get; set; } = new();
}

public class UpdateAssetMaintenanceTicketCommand : IRequest<bool>
{
    public UpdateAssetMaintenanceTicketDto Dto { get; set; } = new();
}

public class DeleteAssetMaintenanceTicketCommand : IRequest<bool>
{
    public long Id { get; set; }
}