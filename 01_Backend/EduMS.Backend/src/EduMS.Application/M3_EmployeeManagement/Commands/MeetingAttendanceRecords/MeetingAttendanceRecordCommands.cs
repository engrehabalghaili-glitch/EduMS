using EduMS.Application.M3_EmployeeManagement.DTOs.MeetingAttendanceRecords;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.MeetingAttendanceRecords;

public class CreateMeetingAttendanceRecordCommand : IRequest<long>
{
    public CreateMeetingAttendanceRecordDto Dto { get; set; } = new();
}

public class UpdateMeetingAttendanceRecordCommand : IRequest<bool>
{
    public UpdateMeetingAttendanceRecordDto Dto { get; set; } = new();
}

public class DeleteMeetingAttendanceRecordCommand : IRequest<bool>
{
    public long Id { get; set; }
}