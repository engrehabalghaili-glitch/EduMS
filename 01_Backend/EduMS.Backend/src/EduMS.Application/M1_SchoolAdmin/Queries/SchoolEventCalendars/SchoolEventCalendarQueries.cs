using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolEventCalendars;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.SchoolEventCalendars;

public class GetSchoolEventCalendarByIdQuery : IRequest<SchoolEventCalendarDto>
{
    public long Id { get; set; }
}

public class GetAllSchoolEventCalendarsQuery : IRequest<IEnumerable<SchoolEventCalendarDto>>
{
}