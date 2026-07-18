using EduMS.Application.M1_SchoolAdmin.DTOs.Subjects;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Subjects;

public class GetSubjectByIdQuery : IRequest<SubjectDto>
{
    public long Id { get; set; }
}

public class GetAllSubjectsQuery : IRequest<IEnumerable<SubjectDto>>
{
}