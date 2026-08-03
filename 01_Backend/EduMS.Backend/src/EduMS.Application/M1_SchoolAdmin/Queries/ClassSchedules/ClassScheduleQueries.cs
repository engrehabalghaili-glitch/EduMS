using EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ClassSchedules;

public class GetClassScheduleByIdQuery : IRequest<ClassScheduleDto>
{
    public long Id { get; set; }
}

public class GetAllClassSchedulesQuery : IRequest<IEnumerable<ClassScheduleDto>>
{
}