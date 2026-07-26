using EduMS.Application.M7_EmergencyManagement.DTOs.RemediationPlans;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M7_EmergencyManagement.Queries.RemediationPlans;

public class GetRemediationPlanByIdQuery : IRequest<RemediationPlanDto>
{
    public long Id { get; set; }
}

public class GetAllRemediationPlansQuery : IRequest<IEnumerable<RemediationPlanDto>>
{
}