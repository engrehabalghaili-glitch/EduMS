using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentFinancialAidApplication : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public string ApplicationReferenceNumber { get; set; } = string.Empty;
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    public int AidCategory { get; set; } // 1=OrphanSupport, 2=LowIncomeWelfare, 3=MeritScholarship, 4=StaffChildDiscount
    public decimal RequestedAidAmountOrPercentage { get; set; }
    public decimal VerifiedGuardianAnnualIncome { get; set; }
    public int FamilyMembersCount { get; set; }
    public int ApplicationStatus { get; set; } // 1=UnderReview, 2=ApprovedPartial, 3=ApprovedFull, 4=Rejected
    public decimal ApprovedDiscountPercentage { get; set; }
    public long? ReviewedByCommitteeEmployeeId { get; set; }
    public string? IncomeProofAttachmentUrl { get; set; }
    public string? CommitteeDecisionRemarks { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Guardian? Guardian { get; set; }
}
