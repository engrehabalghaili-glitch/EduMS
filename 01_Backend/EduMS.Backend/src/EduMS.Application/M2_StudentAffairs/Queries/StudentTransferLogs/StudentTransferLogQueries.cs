using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransferLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentTransferLogs;

public class GetStudentTransferLogByIdQuery : IRequest<StudentTransferLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentTransferLogsQuery : IRequest<IEnumerable<StudentTransferLogDto>>
{
}