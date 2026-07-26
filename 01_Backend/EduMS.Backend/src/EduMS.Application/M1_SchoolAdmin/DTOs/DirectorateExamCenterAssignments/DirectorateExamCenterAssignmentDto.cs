using System;

namespace EduMS.Application.M1_SchoolAdmin.DTOs.DirectorateExamCenterAssignments;

public class DirectorateExamCenterAssignmentDto
{
    public long Id { get; set; }
    public long DirectorateId { get; set; }
    public long HostedAtSchoolId { get; set; }
    public string ExamCenterCode { get; set; } = string.Empty;
    public string ExamSessionTitleAr { get; set; } = string.Empty;
    public string AcademicYear { get; set; } = string.Empty;
    public int TargetEducationalStageId { get; set; }
    public int TotalAllocatedCandidatesCount { get; set; }
    public int TotalExaminationRoomsCount { get; set; }
    public long? ChiefSuperintendentEmployeeId { get; set; }
    public long? ResidentSecurityOfficerEmployeeId { get; set; }
    public DateTime SessionStartDate { get; set; }
    public DateTime SessionEndDate { get; set; }
    public int CenterStatus { get; set; }

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
