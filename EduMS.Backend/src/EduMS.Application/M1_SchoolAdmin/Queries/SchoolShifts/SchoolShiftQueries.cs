using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolShifts;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolShifts;

public class GetSchoolShiftByIdQuery : IRequest<SchoolShiftDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolShiftsQuery : IRequest<IEnumerable<SchoolShiftDto>>
{
}