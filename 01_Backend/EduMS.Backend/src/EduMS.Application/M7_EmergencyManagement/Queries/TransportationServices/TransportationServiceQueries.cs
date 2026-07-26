using EduMS.Application.M7_EmergencyManagement.DTOs.TransportationServices;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.TransportationServices;

public class GetTransportationServiceByIdQuery : IRequest<TransportationServiceDto>
{
    public long Id { get; set; }
}

public class GetAllTransportationServicesQuery : IRequest<IEnumerable<TransportationServiceDto>>
{
}