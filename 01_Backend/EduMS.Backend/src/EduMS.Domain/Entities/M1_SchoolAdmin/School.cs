using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

public class School : BaseAuditableEntity
{
    public long? DirectorateId { get; set; } // FK to Directorate entity
    public long? EducationalStageId { get; set; } // FK to EducationalStage entity
    public string SchoolNameAr { get; set; } = string.Empty;
    public string SchoolNameEn { get; set; } = string.Empty;
    public string SchoolCode { get; set; } = string.Empty; // Unique identifier code
    public string Directorate { get; set; } = string.Empty; // Educational directorate string legacy
    public string Governorate { get; set; } = string.Empty; // Governorate
    public DateTime? EstablishmentDate { get; set; }
    public string? ContactPhone { get; set; }
    public string? ContactEmail { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? PostalAddress { get; set; }
    public string? TaxRegistrationNumber { get; set; }
    public string? CommercialLicenseNumber { get; set; }
    public int MaxStudentCapacity { get; set; }
    public bool IsAccredited { get; set; }
    public bool IsActive { get; set; } = true;

    // Intra-Module Navigation Properties (M1)
    public virtual Directorate? DirectorateEntity { get; set; }
    public virtual EducationalStage? EducationalStage { get; set; }
    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    public virtual ICollection<ClassSchedule> ClassSchedules { get; set; } = new List<ClassSchedule>();
    public virtual ICollection<AcademicBranchConfigLog> AcademicBranchConfigLogs { get; set; } = new List<AcademicBranchConfigLog>();
    public virtual ICollection<SchoolEventCalendar> EventCalendars { get; set; } = new List<SchoolEventCalendar>();
    public virtual ICollection<GradingScaleBound> GradingScaleBounds { get; set; } = new List<GradingScaleBound>();
    public virtual ICollection<EducationalSupervisionVisit> SupervisionVisits { get; set; } = new List<EducationalSupervisionVisit>();
    public virtual ICollection<SchoolFacility> Facilities { get; set; } = new List<SchoolFacility>();
    public virtual ICollection<SchoolShift> Shifts { get; set; } = new List<SchoolShift>();
    public virtual ICollection<SchoolAccreditationLog> AccreditationLogs { get; set; } = new List<SchoolAccreditationLog>();
    public virtual ICollection<CurriculumTextbookDistribution> TextbookDistributions { get; set; } = new List<CurriculumTextbookDistribution>();
    public virtual ICollection<ExamDistributionTimetable> ExamTimetables { get; set; } = new List<ExamDistributionTimetable>();
    public virtual ICollection<AcademicWarningPolicy> WarningPolicies { get; set; } = new List<AcademicWarningPolicy>();
    public virtual ICollection<SchoolAnnouncementLog> AnnouncementLogs { get; set; } = new List<SchoolAnnouncementLog>();
    public virtual ICollection<VisitorEntryLog> VisitorEntryLogs { get; set; } = new List<VisitorEntryLog>();
    public virtual ICollection<SchoolTransportationRoute> TransportationRoutes { get; set; } = new List<SchoolTransportationRoute>();
    public virtual ICollection<SchoolCanteenItem> CanteenItems { get; set; } = new List<SchoolCanteenItem>();
    public virtual ICollection<SchoolOperationalBudgetLog> OperationalBudgetLogs { get; set; } = new List<SchoolOperationalBudgetLog>();
    public virtual ICollection<TrainingCourseOffering> TrainingCourseOfferings { get; set; } = new List<TrainingCourseOffering>();

    // Cross-Module Navigation Collections (Bridge Contracts)
    public virtual ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<AcademicLockPeriod> AcademicLockPeriods { get; set; } = new List<AcademicLockPeriod>();
    public virtual ICollection<AssetAllocation> AssetAllocations { get; set; } = new List<AssetAllocation>();
    public virtual ICollection<FeeStructure> FeeStructures { get; set; } = new List<FeeStructure>();
    public virtual ICollection<StatisticalReportSnapshot> StatisticalReportSnapshots { get; set; } = new List<StatisticalReportSnapshot>();
    public virtual ICollection<EmergencyPlan> EmergencyPlans { get; set; } = new List<EmergencyPlan>();
    public virtual ICollection<EmergencyIncident> EmergencyIncidents { get; set; } = new List<EmergencyIncident>();
    public virtual ICollection<SystemUser> SystemUsers { get; set; } = new List<SystemUser>();
    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
    public virtual ICollection<JournalEntry> JournalEntries { get; set; } = new List<JournalEntry>();
    public virtual ICollection<PaymentVoucher> PaymentVouchers { get; set; } = new List<PaymentVoucher>();
    public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; } = new List<StudentEnrollment>();
    public virtual ICollection<OrganizationalSector> OrganizationalSectors { get; set; } = new List<OrganizationalSector>();
}
