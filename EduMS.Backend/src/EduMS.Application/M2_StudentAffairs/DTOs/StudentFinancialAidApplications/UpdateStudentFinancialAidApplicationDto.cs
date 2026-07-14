using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentFinancialAidApplications;

public class UpdateStudentFinancialAidApplicationDto
{
    public long Id { get; set; }
    public long GuardianId { get; set; }
    public string ApplicationReferenceNumber { get; set; }
    public DateTime ApplicationDate { get; set; }
    public int AidCategory { get; set; }
    public decimal RequestedAidAmountOrPercentage { get; set; }
    public decimal VerifiedGuardianAnnualIncome { get; set; }
    public int FamilyMembersCount { get; set; }
    public decimal ApprovedDiscountPercentage { get; set; }
    public long? ReviewedByCommitteeEmployeeId { get; set; }
    public string? IncomeProofAttachmentUrl { get; set; }
    public string? CommitteeDecisionRemarks { get; set; }
}
