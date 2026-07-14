using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;

public class UpdateEducationalStageDto
{
    public long Id { get; set; }
    public string StageCode { get; set; }
    public string StageNameAr { get; set; }
    public string StageNameEn { get; set; }
    public int MinAge { get; set; }
    public int MaxAge { get; set; }
    public int DefaultDurationYears { get; set; }
    public string? MinistryCurriculumCode { get; set; }
    public bool RequiresGraduationCertificate { get; set; }
    public int DisplayOrder { get; set; }
}
