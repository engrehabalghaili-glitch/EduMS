using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolEventCalendars;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolEventCalendars;

public class CreateSchoolEventCalendarCommand : IRequest<long>
{
    public CreateSchoolEventCalendarDto Dto { get; set; } = new();
}

public class UpdateSchoolEventCalendarCommand : IRequest<bool>
{
    public UpdateSchoolEventCalendarDto Dto { get; set; } = new();
}

public class DeleteSchoolEventCalendarCommand : IRequest<bool>
{
    public long Id { get; set; }
}