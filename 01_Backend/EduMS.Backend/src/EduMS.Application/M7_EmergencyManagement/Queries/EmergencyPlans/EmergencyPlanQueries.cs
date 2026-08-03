using EduMS.Application.M7_EmergencyManagement.DTOs.EmergencyPlans;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.EmergencyPlans;

public class GetEmergencyPlanByIdQuery : IRequest<EmergencyPlanDto>
{
    public long Id { get; set; }
}

public class GetAllEmergencyPlansQuery : IRequest<IEnumerable<EmergencyPlanDto>>
{
}