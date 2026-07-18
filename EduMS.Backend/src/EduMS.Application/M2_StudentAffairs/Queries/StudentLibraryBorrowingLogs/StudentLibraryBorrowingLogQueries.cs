using EduMS.Application.M2_StudentAffairs.DTOs.StudentLibraryBorrowingLogs;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M2_StudentAffairs.Queries.StudentLibraryBorrowingLogs;

public class GetStudentLibraryBorrowingLogByIdQuery : IRequest<StudentLibraryBorrowingLogDto>
{
    public long Id { get; set; }
}

public class GetAllStudentLibraryBorrowingLogsQuery : IRequest<IEnumerable<StudentLibraryBorrowingLogDto>>
{
}