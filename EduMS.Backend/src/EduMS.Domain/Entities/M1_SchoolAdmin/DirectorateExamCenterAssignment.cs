using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class DirectorateExamCenterAssignment : BaseAuditableEntity
{
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
    public int CenterStatus { get; set; } = 1; // 1=Assigned, 2=ActiveExamsInProgress, 3=CompletedClosed, 4=Cancelled

    // Navigation Properties
    public virtual Directorate? Directorate { get; set; }
    public virtual School? HostedAtSchool { get; set; }
}
