using EduMS.Application.M2_StudentAffairs.DTOs.AttendanceDetails;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.AttendanceDetails;

public class CreateAttendanceDetailCommand : IRequest<long>
{
    public CreateAttendanceDetailDto Dto { get; set; } = new();
}

public class UpdateAttendanceDetailCommand : IRequest<bool>
{
    public UpdateAttendanceDetailDto Dto { get; set; } = new();
}

public class DeleteAttendanceDetailCommand : IRequest<bool>
{
    public long Id { get; set; }
}