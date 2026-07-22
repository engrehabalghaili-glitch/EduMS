using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyClosures;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyClosures;

public class GetEmergencyClosureByIdQuery : IRequest<EmergencyClosureDto>
{
    public long Id { get; set; }
}

public class GetAllEmergencyClosuresQuery : IRequest<IEnumerable<EmergencyClosureDto>>
{
}