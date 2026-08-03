using EduMS.Application.M2_StudentAffairs.DTOs.StudentComplaintLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentComplaintLogs;

public class GetStudentComplaintLogByIdQuery : IRequest<StudentComplaintLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentComplaintLogsQuery : IRequest<IEnumerable<StudentComplaintLogDto>>
{
}