using EduMS.Application.M2_StudentAffairs.DTOs.StudentLibraryBorrowingLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentLibraryBorrowingLogs;

public class CreateStudentLibraryBorrowingLogCommand : IRequest<long>
{
    public CreateStudentLibraryBorrowingLogDto Dto { get; set; } = new();
}

public class UpdateStudentLibraryBorrowingLogCommand : IRequest<bool>
{
    public UpdateStudentLibraryBorrowingLogDto Dto { get; set; } = new();
}

public class DeleteStudentLibraryBorrowingLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}