using EduMS.Application.M1_SchoolAdmin.DTOs.GradeCapacities;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.GradeCapacities;

public class GetGradeCapacityByIdQuery : IRequest<GradeCapacityDto>
{
    public long Id { get; set; }
}

public class GetAllGradeCapacitiesQuery : IRequest<IEnumerable<GradeCapacityDto>>
{
}