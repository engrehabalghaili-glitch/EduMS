using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentLibraryBorrowingLogs;

public class StudentLibraryBorrowingLogDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long SchoolLibraryItemId { get; set; }
    public DateTime BorrowedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int BorrowingStatus { get; set; }
    public decimal LatePenaltyFeeAmount { get; set; }
    public bool IsPenaltyFeePaid { get; set; }
    public long? IssuedByLibrarianEmployeeId { get; set; }
    public string? Remarks { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public long CreatedByUserId { get; set; }
    public DateTimeOffset? ModifiedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public Guid VersionToken { get; set; }
    public DateTimeOffset? LastSyncedAt { get; set; }
    public string SyncStatus { get; set; } = string.Empty;
}
