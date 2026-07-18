using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolLevels;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolLevels;

public class GetSchoolLevelByIdQuery : IRequest<SchoolLevelDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolLevelsQuery : IRequest<IEnumerable<SchoolLevelDto>>
{
}