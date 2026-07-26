using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentExitClearance : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string ClearanceReferenceNumber { get; set; } = string.Empty;
    public int ClearanceReason { get; set; } // 1=FinalGraduation, 2=TransferToAnotherSchool, 3=Withdrawal
    public DateTime InitiationDate { get; set; } = DateTime.UtcNow;
    public DateTime? CompletionDate { get; set; }
    public bool IsLibraryClearanceApproved { get; set; }
    public bool IsFinancialClearanceApproved { get; set; }
    public bool IsCanteenClearanceApproved { get; set; }
    public bool IsSportsEquipmentClearanceApproved { get; set; }
    public int OverallClearanceStatus { get; set; } = 1; // 1=PendingChecklist, 2=ApprovedCleared, 3=RejectedDueToDues
    public long? ApprovedByDirectorEmployeeId { get; set; }
    public string? ClearanceNotes { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
    public virtual Employee? ApprovedByDirectorEmployee { get; set; }
}
