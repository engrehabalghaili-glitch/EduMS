using EduMS.Application.M3_EmployeeManagement.DTOs.MeetingAttendanceRecords;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.MeetingAttendanceRecords;

public class GetMeetingAttendanceRecordByIdQuery : IRequest<MeetingAttendanceRecordDto>
{
    public long Id { get; set; }
}

public class GetAllMeetingAttendanceRecordsQuery : IRequest<IEnumerable<MeetingAttendanceRecordDto>>
{
}