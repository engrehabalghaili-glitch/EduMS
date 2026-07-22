using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalSupervisionVisits;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.EducationalSupervisionVisits;

public class GetEducationalSupervisionVisitByIdQuery : IRequest<EducationalSupervisionVisitDto>
{
    public long Id { get; set; }
}

public class GetAllEducationalSupervisionVisitsQuery : IRequest<IEnumerable<EducationalSupervisionVisitDto>>
{
}