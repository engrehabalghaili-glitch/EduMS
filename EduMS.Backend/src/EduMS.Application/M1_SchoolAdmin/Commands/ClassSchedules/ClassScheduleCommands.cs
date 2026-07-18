using EduMS.Application.M1_SchoolAdmin.DTOs.ClassSchedules;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ClassSchedules;

public class CreateClassScheduleCommand : IRequest<long>
{
    public CreateClassScheduleDto Dto { get; set; } = new();
}

public class UpdateClassScheduleCommand : IRequest<bool>
{
    public UpdateClassScheduleDto Dto { get; set; } = new();
}

public class DeleteClassScheduleCommand : IRequest<bool>
{
    public long Id { get; set; }
}