using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;

public class CreateStudentFinancialAidApplicationDto
{
    public long StudentId { get; set; }
    public long GuardianId { get; set; }
    public string ApplicationReferenceNumber { get; set; } = string.Empty;
    public DateTime ApplicationDate { get; set; } = DateTime.UtcNow;
    public int AidCategory { get; set; }
    public decimal RequestedAidAmountOrPercentage { get; set; }
    public decimal VerifiedGuardianAnnualIncome { get; set; }
    public int FamilyMembersCount { get; set; }
    public int ApplicationStatus { get; set; }
    public decimal ApprovedDiscountPercentage { get; set; }
    public long? ReviewedByCommitteeEmployeeId { get; set; }
    public string? IncomeProofAttachmentUrl { get; set; }
    public string? CommitteeDecisionRemarks { get; set; }
}
