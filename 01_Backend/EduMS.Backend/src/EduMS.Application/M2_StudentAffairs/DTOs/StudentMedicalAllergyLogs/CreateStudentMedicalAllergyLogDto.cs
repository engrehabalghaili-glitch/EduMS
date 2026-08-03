using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentMedicalAllergyLogs;

public class CreateStudentMedicalAllergyLogDto
{
    public long StudentId { get; set; }
    public string AllergyOrConditionName { get; set; }
    public int SeverityLevel { get; set; }
    public string? ReactionSymptoms { get; set; }
    public string? EmergencyActionProtocol { get; set; }
    public string? RequiredMedicationName { get; set; }
    public DateTime ReportedDate { get; set; }
    public bool IsEpiPenRequired { get; set; }
    public string? DoctorContactNumber { get; set; }
    public DateTime? LastReactionDate { get; set; }
}
