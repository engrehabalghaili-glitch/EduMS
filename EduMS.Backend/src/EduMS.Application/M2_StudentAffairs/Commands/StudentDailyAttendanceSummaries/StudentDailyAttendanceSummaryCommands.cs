using EduMS.Application.M2_StudentAffairs.DTOs.StudentDailyAttendanceSummaries;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentDailyAttendanceSummaries;

public class CreateStudentDailyAttendanceSummaryCommand : IRequest<long>
{
    public CreateStudentDailyAttendanceSummaryDto Dto { get; set; } = new();
}

public class UpdateStudentDailyAttendanceSummaryCommand : IRequest<bool>
{
    public UpdateStudentDailyAttendanceSummaryDto Dto { get; set; } = new();
}

public class DeleteStudentDailyAttendanceSummaryCommand : IRequest<bool>
{
    public long Id { get; set; }
}