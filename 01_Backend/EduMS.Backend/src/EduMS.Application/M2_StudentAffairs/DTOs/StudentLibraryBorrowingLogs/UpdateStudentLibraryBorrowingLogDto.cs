using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentLibraryBorrowingLogs;

public class UpdateStudentLibraryBorrowingLogDto
{
    public long Id { get; set; }
    public long SchoolLibraryItemId { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public decimal LatePenaltyFeeAmount { get; set; }
    public bool IsPenaltyFeePaid { get; set; }
    public long? IssuedByLibrarianEmployeeId { get; set; }
    public string? Remarks { get; set; }
}
