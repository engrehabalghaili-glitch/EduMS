using EduMS.Application.M2_StudentAffairs.DTOs.StudentDailyAttendanceSummaries;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentDailyAttendanceSummaries;

public class GetStudentDailyAttendanceSummaryByIdQuery : IRequest<StudentDailyAttendanceSummaryDto>
{
    public long Id { get; set; }
}

public class GetAllStudentDailyAttendanceSummariesQuery : IRequest<IEnumerable<StudentDailyAttendanceSummaryDto>>
{
}