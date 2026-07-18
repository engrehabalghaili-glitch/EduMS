using EduMS.Application.M3_EmployeeManagement.DTOs.TeacherSchedules;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.TeacherSchedules;

public class CreateTeacherScheduleCommand : IRequest<long>
{
    public CreateTeacherScheduleDto Dto { get; set; } = new();
}

public class UpdateTeacherScheduleCommand : IRequest<bool>
{
    public UpdateTeacherScheduleDto Dto { get; set; } = new();
}

public class DeleteTeacherScheduleCommand : IRequest<bool>
{
    public long Id { get; set; }
}