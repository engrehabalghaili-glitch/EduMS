using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyHostings;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyHostings;

public class GetEmergencyHostingByIdQuery : IRequest<EmergencyHostingDto>
{
    public long Id { get; set; }
}

public class GetAllEmergencyHostingsQuery : IRequest<IEnumerable<EmergencyHostingDto>>
{
}