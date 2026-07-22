using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicWarningPolicies;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.AcademicWarningPolicies;

public class GetAcademicWarningPolicyByIdQuery : IRequest<AcademicWarningPolicyDto>
{
    public long Id { get; set; }
}

public class GetAllAcademicWarningPoliciesQuery : IRequest<IEnumerable<AcademicWarningPolicyDto>>
{
}