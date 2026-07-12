namespace EduMS.Domain.Entities;

public class Student : Person
{
    public string EnrollmentNumber { get; set; } = string.Empty;
    public DateTime EnrollmentDate { get; set; }
    public long? SchoolId { get; set; } // Reference to current School (M1)
    public long? ClassroomId { get; set; } // Reference to current Classroom (M1)
    public long? GuardianId { get; set; } // Reference to Guardian (M2) legacy primary link
    public string? PreviousSchoolName { get; set; }
    public int AdmissionGradeLevel { get; set; }
    public string? CurrentAcademicYear { get; set; }
    public int StudentStatus { get; set; } = 1; // e.g. 1=Regular, 2=Suspended, 3=Transferred, 4=Graduated, 5=Withdrawn
    public string? SpecialEducationNeeds { get; set; }
    public string? BusStopLocationDescription { get; set; }
    public bool IsActive { get; set; } = true;

    // Cross-Module Navigation Properties
    public virtual School? School { get; set; }
    public virtual Classroom? Classroom { get; set; }
    public virtual Guardian? Guardian { get; set; }
    public virtual ICollection<StudentTransferLog> TransferLogs { get; set; } = new List<StudentTransferLog>();
    public virtual ICollection<FeeInvoice> FeeInvoices { get; set; } = new List<FeeInvoice>();

    // Operational Intra-Module Navigation Collections (M2 Core)
    public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; } = new List<AttendanceDetail>();
    public virtual ICollection<BehavioralLog> BehavioralLogs { get; set; } = new List<BehavioralLog>();
    public virtual ICollection<StudentEnrollment> Enrollments { get; set; } = new List<StudentEnrollment>();
    public virtual ICollection<StudentHealthRecord> HealthRecords { get; set; } = new List<StudentHealthRecord>();
    public virtual ICollection<StudentAssessment> Assessments { get; set; } = new List<StudentAssessment>();
    public virtual ICollection<StudentIdentityDocument> IdentityDocuments { get; set; } = new List<StudentIdentityDocument>();
    public virtual ICollection<StudentAttachment> Attachments { get; set; } = new List<StudentAttachment>();
    public virtual ICollection<StudentGuardianRelationship> GuardianRelationships { get; set; } = new List<StudentGuardianRelationship>();
    public virtual ICollection<StudentExemption> Exemptions { get; set; } = new List<StudentExemption>();
    public virtual ICollection<StudentActivityParticipation> ActivityParticipations { get; set; } = new List<StudentActivityParticipation>();
    public virtual ICollection<StudentAbsenceExcusal> AbsenceExcusals { get; set; } = new List<StudentAbsenceExcusal>();
    public virtual ICollection<StudentExemplaryRecognition> ExemplaryRecognitions { get; set; } = new List<StudentExemplaryRecognition>();

    // Granular Expanded Sub-Records & Lookups (M2 Advanced)
    public virtual ICollection<StudentDisciplinaryHistory> DisciplinaryHistories { get; set; } = new List<StudentDisciplinaryHistory>();
    public virtual ICollection<DetailedAcademicWarningLog> DetailedAcademicWarningLogs { get; set; } = new List<DetailedAcademicWarningLog>();
    public virtual ICollection<StudentTransportationSubscription> TransportationSubscriptions { get; set; } = new List<StudentTransportationSubscription>();
    public virtual ICollection<StudentCanteenPurchaseLog> CanteenPurchaseLogs { get; set; } = new List<StudentCanteenPurchaseLog>();
    public virtual ICollection<StudentParentConferenceReservation> ConferenceReservations { get; set; } = new List<StudentParentConferenceReservation>();
    public virtual ICollection<StudentMedicalAllergyLog> MedicalAllergyLogs { get; set; } = new List<StudentMedicalAllergyLog>();
    public virtual ICollection<StudentDailyAttendanceSummary> DailyAttendanceSummaries { get; set; } = new List<StudentDailyAttendanceSummary>();
    public virtual ICollection<StudentAssignmentSubmission> AssignmentSubmissions { get; set; } = new List<StudentAssignmentSubmission>();
    public virtual ICollection<StudentPsychologicalCounselingLog> PsychologicalCounselingLogs { get; set; } = new List<StudentPsychologicalCounselingLog>();
    public virtual ICollection<StudentSkillAndTalentRecord> SkillAndTalentRecords { get; set; } = new List<StudentSkillAndTalentRecord>();
}
