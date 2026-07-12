using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class Classroom : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string ClassroomCode { get; set; } = string.Empty; // e.g. "G10-A"
    public string ClassroomNameAr { get; set; } = string.Empty;
    public string ClassroomNameEn { get; set; } = string.Empty;
    public int GradeLevel { get; set; } // 1 to 12
    public int Capacity { get; set; } = 30;
    public string? RoomNumber { get; set; }
    public int FloorLevel { get; set; }
    public string? BuildingSection { get; set; }
    public long? HomeroomTeacherEmployeeId { get; set; }
    public bool IsSmartClassroom { get; set; }
    public bool IsActive { get; set; } = true;

    // Intra-Module and Operational Navigation Collections
    public virtual School? School { get; set; }
    public virtual ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    public virtual ICollection<ClassroomOperationalRule> OperationalRules { get; set; } = new List<ClassroomOperationalRule>();
    public virtual ICollection<ClassroomResourceAllocation> ResourceAllocations { get; set; } = new List<ClassroomResourceAllocation>();
    public virtual ICollection<ExamDistributionTimetable> ExamTimetables { get; set; } = new List<ExamDistributionTimetable>();

    // Cross-Module Navigation Properties (M2 and M4)
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<AssetAllocation> AssetAllocations { get; set; } = new List<AssetAllocation>();
    public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; } = new List<AttendanceDetail>();
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();
    public virtual ICollection<StudentAssessment> StudentAssessments { get; set; } = new List<StudentAssessment>();
    public virtual ICollection<StudentAssignmentSubmission> AssignmentSubmissions { get; set; } = new List<StudentAssignmentSubmission>();
}
