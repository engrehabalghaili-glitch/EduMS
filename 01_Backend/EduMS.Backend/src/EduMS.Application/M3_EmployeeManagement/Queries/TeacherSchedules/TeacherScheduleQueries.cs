using EduMS.Application.M3_EmployeeManagement.DTOs.TeacherSchedules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.TeacherSchedules;

public class GetTeacherScheduleByIdQuery : IRequest<TeacherScheduleDto>
{
    public long Id { get; set; }
}

public class GetAllTeacherSchedulesQuery : IRequest<IEnumerable<TeacherScheduleDto>>
{
}