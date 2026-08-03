using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomOperationalRules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ClassroomOperationalRules;

public class GetClassroomOperationalRuleByIdQuery : IRequest<ClassroomOperationalRuleDto>
{
    public long Id { get; set; }
}

public class GetAllClassroomOperationalRulesQuery : IRequest<IEnumerable<ClassroomOperationalRuleDto>>
{
}