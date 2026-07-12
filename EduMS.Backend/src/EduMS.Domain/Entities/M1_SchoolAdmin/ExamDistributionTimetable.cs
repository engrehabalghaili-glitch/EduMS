using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class ExamDistributionTimetable : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long SubjectId { get; set; }
    public long ClassroomId { get; set; }
    public long? FacilityId { get; set; }
    public long? ProctorEmployeeId { get; set; }
    public DateTime ExamDate { get; set; }
    public string StartTime { get; set; } = string.Empty; // e.g. "08:30"
    public string EndTime { get; set; } = string.Empty; // e.g. "10:30"
    public int MaxSeatCount { get; set; }
    public int Status { get; set; } // 1=Scheduled, 2=InSession, 3=Completed, 4=Cancelled
    public string? ExamSessionNameAr { get; set; }
    public int ExamType { get; set; } = 1; // 1=Midterm, 2=Final, 3=MakeUp, 4=Quiz
    public int TermSemesterNumber { get; set; } = 1;
    public long? AssistantProctorEmployeeId { get; set; }
    public bool IsSeatingChartPublished { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual SchoolFacility? Facility { get; set; }
    public virtual Employee? ProctorEmployee { get; set; }
}
