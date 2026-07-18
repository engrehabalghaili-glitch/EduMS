using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAttendances;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeAttendances;

public class GetEmployeeAttendanceByIdQuery : IRequest<EmployeeAttendanceDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeAttendancesQuery : IRequest<IEnumerable<EmployeeAttendanceDto>>
{
}