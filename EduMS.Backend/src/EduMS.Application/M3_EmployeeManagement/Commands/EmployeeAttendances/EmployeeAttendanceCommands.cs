using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAttendances;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeAttendances;

public class CreateEmployeeAttendanceCommand : IRequest<long>
{
    public CreateEmployeeAttendanceDto Dto { get; set; } = new();
}

public class UpdateEmployeeAttendanceCommand : IRequest<bool>
{
    public UpdateEmployeeAttendanceDto Dto { get; set; } = new();
}

public class DeleteEmployeeAttendanceCommand : IRequest<bool>
{
    public long Id { get; set; }
}