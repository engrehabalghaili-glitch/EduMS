using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class ClassSchedule : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long ClassroomId { get; set; }
    public long SubjectId { get; set; }
    public long? AssignedEmployeeId { get; set; }
    public int DayOfWeek { get; set; } // 1=Sunday to 7=Saturday
    public int PeriodNumber { get; set; } // 1 to 8
    public string? RoomCode { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public int TermSemesterNumber { get; set; } = 1;
    public int ScheduleType { get; set; } = 1; // 1=Regular, 2=ExamPrep, 3=Activity
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual Subject? Subject { get; set; }
    public virtual Employee? AssignedEmployee { get; set; }
}
