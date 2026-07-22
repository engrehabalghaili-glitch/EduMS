using EduMS.Application.M7_EmergencyManagement.DTOs.ExternalParticipations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.ExternalParticipations;

public class GetExternalParticipationByIdQuery : IRequest<ExternalParticipationDto>
{
    public long Id { get; set; }
}

public class GetAllExternalParticipationsQuery : IRequest<IEnumerable<ExternalParticipationDto>>
{
}