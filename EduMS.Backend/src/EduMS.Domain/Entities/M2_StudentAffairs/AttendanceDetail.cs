using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class AttendanceDetail : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long ClassroomId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int AttendanceStatus { get; set; } // 1=Present, 2=Absent, 3=Excused, 4=Late
    public string? AbsenceReason { get; set; }
    public int DurationMinutes { get; set; }
    public long? RecordedByEmployeeId { get; set; }
    public int PeriodNumber { get; set; }
    public string? CheckInTime { get; set; }
    public string? CheckOutTime { get; set; }
    public bool IsParentNotified { get; set; }
    public string? ExcusalDocumentUrl { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual Employee? RecordedByEmployee { get; set; }
}
