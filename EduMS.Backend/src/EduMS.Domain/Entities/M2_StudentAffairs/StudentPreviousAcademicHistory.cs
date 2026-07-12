using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentPreviousAcademicHistory : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public string PreviousSchoolName { get; set; } = string.Empty;
    public string PreviousDirectorateName { get; set; } = string.Empty;
    public string AcademicYearCompleted { get; set; } = string.Empty;
    public int GradeLevelCompleted { get; set; }
    public decimal CumulativeScoreEarned { get; set; }
    public decimal MaximumPossibleScore { get; set; }
    public decimal PercentagePercentage { get; set; }
    public string? LeavingCertificateNumber { get; set; }
    public DateTime LeavingDate { get; set; }
    public int VerificationStatus { get; set; } = 1; // 1=SubmittedByParent, 2=VerifiedByRegistrar, 3=RejectedUnverified
    public string? TranscriptDocumentUrl { get; set; }

    // Navigation Property
    public virtual Student? Student { get; set; }
}
