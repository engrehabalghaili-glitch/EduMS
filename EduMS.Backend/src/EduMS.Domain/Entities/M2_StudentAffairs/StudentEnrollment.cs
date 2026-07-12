using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class StudentEnrollment : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long ClassroomId { get; set; }
    public string AcademicYear { get; set; } = string.Empty;
    public int SemesterNumber { get; set; } // 1 or 2
    public DateTime EnrollmentDate { get; set; }
    public int EnrollmentStatus { get; set; } // 1=Active, 2=Suspended, 3=Completed, 4=Withdrawn
    public bool IsCurrentTerm { get; set; } = true;
    public int EnrollmentType { get; set; } = 1; // 1=NewAdmission, 2=ReEnrollment, 3=TransferIn
    public int AssignedRollNumber { get; set; }
    public int PromotionStatus { get; set; } = 1; // 1=Pending, 2=Promoted, 3=Retained, 4=Conditional
    public string? EnrollmentRemarks { get; set; }

    // Navigation Properties
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
    public virtual Classroom? Classroom { get; set; }
}
