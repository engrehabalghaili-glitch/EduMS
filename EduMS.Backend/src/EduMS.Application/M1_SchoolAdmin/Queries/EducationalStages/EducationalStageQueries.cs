using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.EducationalStages;

public class GetEducationalStageByIdQuery : IRequest<EducationalStageDto>
{
    public long Id { get; set; }
}

public class GetAllEducationalStagesQuery : IRequest<IEnumerable<EducationalStageDto>>
{
}