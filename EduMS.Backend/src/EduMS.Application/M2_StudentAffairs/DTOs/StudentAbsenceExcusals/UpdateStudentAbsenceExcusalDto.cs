using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentAbsenceExcusals;

public class UpdateStudentAbsenceExcusalDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ExcusalType { get; set; }
    public string ReasonDescription { get; set; } = string.Empty;
    public string? MedicalReportAttachmentUrl { get; set; }
    public int ReviewStatus { get; set; }
    public long? ReviewedByEmployeeId { get; set; }
    public long? SubmittedByGuardianId { get; set; }
    public DateTime SubmissionDate { get; set; }
    public string? ReviewRemarks { get; set; }
}
