using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateExamCenterAssignments;

public class UpdateDirectorateExamCenterAssignmentDto
{
    public long Id { get; set; }
    public long HostedAtSchoolId { get; set; }
    public string ExamCenterCode { get; set; }
    public string ExamSessionTitleAr { get; set; }
    public string AcademicYear { get; set; }
    public int TargetEducationalStageId { get; set; }
    public int TotalAllocatedCandidatesCount { get; set; }
    public int TotalExaminationRoomsCount { get; set; }
    public long? ChiefSuperintendentEmployeeId { get; set; }
    public long? ResidentSecurityOfficerEmployeeId { get; set; }
    public DateTime SessionStartDate { get; set; }
    public DateTime SessionEndDate { get; set; }
}
