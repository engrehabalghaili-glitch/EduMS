using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentLibraryBorrowingLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolLibraryItemId { get; set; }
    public DateTime BorrowedDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public int BorrowingStatus { get; set; } = 1; // 1=ActiveBorrowed, 2=ReturnedOnTime, 3=ReturnedLate, 4=LostOrNotReturned
    public decimal LatePenaltyFeeAmount { get; set; }
    public bool IsPenaltyFeePaid { get; set; }
    public long? IssuedByLibrarianEmployeeId { get; set; }
    public string? Remarks { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual SchoolLibraryItem? LibraryItem { get; set; }
    public virtual Employee? IssuedByLibrarianEmployee { get; set; }
}
