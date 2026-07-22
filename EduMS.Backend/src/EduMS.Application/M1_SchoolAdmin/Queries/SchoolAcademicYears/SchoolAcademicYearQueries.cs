using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolAcademicYears;

public class GetSchoolAcademicYearByIdQuery : IRequest<SchoolAcademicYearDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolAcademicYearsQuery : IRequest<IEnumerable<SchoolAcademicYearDto>>
{
}