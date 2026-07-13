using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;

public class StudentFinancialAidApplicationDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public string ApplicationReferenceNumber { get; set; } = string.Empty;
    public DateTime ApplicationDate { get; set; }
    public int AidCategory { get; set; }
    public decimal RequestedAidAmountOrPercentage { get; set; }
    public decimal VerifiedGuardianAnnualIncome { get; set; }
    public int FamilyMembersCount { get; set; }
    public int ApplicationStatus { get; set; }
    public decimal ApprovedDiscountPercentage { get; set; }
    public long? ReviewedByCommitteeEmployeeId { get; set; }
    public string? IncomeProofAttachmentUrl { get; set; }
    public string? CommitteeDecisionRemarks { get; set; }

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
