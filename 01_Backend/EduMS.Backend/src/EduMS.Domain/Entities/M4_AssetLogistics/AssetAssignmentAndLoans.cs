using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// تخصيص الأصل لمستخدم أو قسم - Asset assignment extracted from ZIP ERD AssetAssignment table (lines 7391-7421).
/// </summary>
public class AssetAssignment : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int AssigneeType { get; set; } // 1=Employee, 2=Student, 3=Department, 4=Lab, 5=Other
    public long AssigneeId { get; set; }
    public string AssigneeName { get; set; } = string.Empty;
    public long? AssignerUserId { get; set; }
    public DateTime AssignmentDate { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public string? AssignmentReason { get; set; }
    public int ConditionAtAssignment { get; set; } // 1=New, 2=Good, 3=NeedsMaintenance
    public string? ConditionNotesAtAssignment { get; set; }
    public int ConditionAtReturn { get; set; }
    public string? ConditionNotesAtReturn { get; set; }
    public decimal PenaltyAmount { get; set; }
    public int PenaltyStatus { get; set; } // 1=Due, 2=Paid, 3=Waived
    public int AssignmentStatus { get; set; } = 1; // 1=Active, 2=Cancelled, 3=Returned, 4=Expired
    public bool IsReturned { get; set; }
    public long? ReturnedToUserId { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// إعارة الأصل مؤقتاً - Asset loan extracted from ZIP ERD AssetLoans table (lines 7423-7450).
/// </summary>
public class AssetLoan : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public int BorrowerType { get; set; } // 1=Student, 2=Employee, 3=Visitor, 4=ExternalEntity
    public long BorrowerId { get; set; }
    public string BorrowerName { get; set; } = string.Empty;
    public string? BorrowerContact { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ExpectedReturnDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    public string? LoanPurpose { get; set; }
    public long? IssuerUserId { get; set; }
    public int ConditionAtLoan { get; set; }
    public int ConditionAtReturn { get; set; }
    public bool IsOverdue { get; set; }
    public int OverdueDays { get; set; }
    public decimal FineAmount { get; set; }
    public bool IsFinePaid { get; set; }
    public DateTime? FinePaidDate { get; set; }
    public int LoanStatus { get; set; } = 1; // 1=Active, 2=Returned, 3=Overdue, 4=Lost
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}

/// <summary>
/// طلب نقل الأصل - Asset transfer request extracted from ZIP ERD AssetTransferRequests table (lines 7452-7479).
/// </summary>
public class AssetTransferRequest : BaseAuditableEntity
{
    public long AssetId { get; set; }
    public long SchoolId { get; set; }
    public string RequestNumber { get; set; } = string.Empty;
    public int FromEntityType { get; set; } // 1=Department, 2=Location, 3=School
    public long FromEntityId { get; set; }
    public int ToEntityType { get; set; }
    public long ToEntityId { get; set; }
    public int TransferType { get; set; } // 1=Spatial, 2=Administrative, 3=InterSchool
    public string? RequestReason { get; set; }
    public long? RequestedByUserId { get; set; }
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public int ApprovalStatus { get; set; } = 1; // 1=UnderReview, 2=Approved, 3=Rejected, 4=Cancelled
    public long? ApprovedByUserId { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? RejectionReason { get; set; }
    public DateTime? TransferExecutionDate { get; set; }
    public long? ExecutedByUserId { get; set; }
    public int RequestStatus { get; set; } = 1; // 1=Open, 2=Approved, 3=Executed, 4=Cancelled
    public string? Notes { get; set; }

    public virtual SchoolAsset? Asset { get; set; }
}
