using EduMS.Application.M7_EmergencyManagement.DTOs.TransportationServices;
using MediatR;

namespace EduMS.Application.M7_EmergencyManagement.Commands.TransportationServices;

public class CreateTransportationServiceCommand : IRequest<long>
{
    public CreateTransportationServiceDto Dto { get; set; } = new();
}

public class UpdateTransportationServiceCommand : IRequest<bool>
{
    public UpdateTransportationServiceDto Dto { get; set; } = new();
}

public class DeleteTransportationServiceCommand : IRequest<bool>
{
    public long Id { get; set; }
}