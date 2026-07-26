using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentPreviousAcademicHistories;

public class UpdateStudentPreviousAcademicHistoryDto
{
    public long Id { get; set; }
    public string PreviousSchoolName { get; set; }
    public string PreviousDirectorateName { get; set; }
    public string AcademicYearCompleted { get; set; }
    public int GradeLevelCompleted { get; set; }
    public decimal CumulativeScoreEarned { get; set; }
    public decimal MaximumPossibleScore { get; set; }
    public decimal PercentagePercentage { get; set; }
    public string? LeavingCertificateNumber { get; set; }
    public DateTime LeavingDate { get; set; }
    public string? TranscriptDocumentUrl { get; set; }
}
