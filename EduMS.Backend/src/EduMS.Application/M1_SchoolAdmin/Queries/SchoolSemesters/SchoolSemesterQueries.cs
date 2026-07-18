using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolSemesters;

public class GetSchoolSemesterByIdQuery : IRequest<SchoolSemesterDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolSemestersQuery : IRequest<IEnumerable<SchoolSemesterDto>>
{
}