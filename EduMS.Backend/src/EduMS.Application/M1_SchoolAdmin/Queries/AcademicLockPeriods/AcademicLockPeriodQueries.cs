using EduMS.Application.M1_SchoolAdmin.DTOs.AcademicLockPeriods;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.AcademicLockPeriods;

public class GetAcademicLockPeriodByIdQuery : IRequest<AcademicLockPeriodDto>
{
    public long Id { get; set; }
}

public class GetAllAcademicLockPeriodsQuery : IRequest<IEnumerable<AcademicLockPeriodDto>>
{
}