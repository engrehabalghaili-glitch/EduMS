using System;

namespace EduMS.Application.M2_StudentAffairs.DTOs.StudentExemplaryRecognitions;

public class UpdateStudentExemplaryRecognitionDto
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; }
    public string RecognitionTitleAr { get; set; } = string.Empty;
    public int Category { get; set; }
    public DateTime AwardDate { get; set; }
    public string? CertificateNumber { get; set; }
    public string? RecognitionTitleEn { get; set; }
    public string? AwardGrantedBy { get; set; }
    public int MeritBonusPoints { get; set; }
    public bool IsFeaturedInSchoolBoard { get; set; }
}
