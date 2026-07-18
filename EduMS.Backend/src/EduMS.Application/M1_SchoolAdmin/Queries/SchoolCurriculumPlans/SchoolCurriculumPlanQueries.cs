using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolCurriculumPlans;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolCurriculumPlans;

public class GetSchoolCurriculumPlanByIdQuery : IRequest<SchoolCurriculumPlanDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolCurriculumPlansQuery : IRequest<IEnumerable<SchoolCurriculumPlanDto>>
{
}