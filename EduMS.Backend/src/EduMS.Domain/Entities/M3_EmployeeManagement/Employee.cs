using System;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// الموظف - Core employee record. Inherits personal identity from the TPT Person hierarchy.
/// Extends with job-specific, payroll, authentication, and credential fields from M3 ERD.
/// Source: faild_053908.txt Employee table lines 5353-5462.
/// </summary>
public class Employee : Person
{
    // Universal Sector Decoupling (M3 Multi-Sector Pointers)
    public long? SchoolId { get; set; }
    public long? DirectorateId { get; set; }
    public long? OrganizationalSectorId { get; set; }
    public int WorkLocationType { get; set; } = 3; // 1=CentralMinistry, 2=RegionalDirectorate, 3=LocalSchool, 4=GuidanceCenter, 5=LogisticsDepot, 6=Other
    
    public string EmployeeCode { get; set; } = string.Empty;
    public string NationalIdNumber { get; set; } = string.Empty;
    public int NationalIdType { get; set; } // 1=Saudi, 2=Resident, 3=GCC, 4=Visitor
    public DateTime? NationalIdExpiryDate { get; set; }
    public DateTime? PassportExpiryDate { get; set; }
    public string? ResidenceNumber { get; set; }
    public DateTime? ResidenceExpiryDate { get; set; }
    public string? ResidenceSponsorName { get; set; }

    // Name fields specific to M3 HR breakdown
    public string FirstNameAr { get; set; } = string.Empty;
    public string FatherNameAr { get; set; } = string.Empty;
    public string GrandfatherNameAr { get; set; } = string.Empty;
    public string FamilyNameAr { get; set; } = string.Empty;
    public string? FirstNameEn { get; set; }
    public string? FamilyNameEn { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Nationality { get; set; }
    public int MaritalStatus { get; set; } // 1=Single, 2=Married, 3=Divorced, 4=Widowed
    public int NumberOfDependents { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public string? BloodType { get; set; }
    public bool HasSpecialNeeds { get; set; }

    // Contact
    public string PhonePrimary { get; set; } = string.Empty;
    public string? PhoneSecondary { get; set; }
    public string? PersonalEmail { get; set; }
    public string OfficialEmail { get; set; } = string.Empty;
    public string? FullAddress { get; set; }
    public string? City { get; set; }
    public string? ProfilePhotoUrl { get; set; }

    // Employment
    public int ContractType { get; set; } // 1=Permanent, 2=Temporary, 3=Seasonal, 4=Probation
    public int EmployeeType { get; set; } // 1=Teacher, 2=Admin, 3=Technical, 4=Supervisor, 5=Director
    public long? DepartmentId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string? JobGrade { get; set; }
    public string? Specialization { get; set; }
    public string? AcademicQualification { get; set; }
    public string? QualificationSource { get; set; }
    public int ExperienceYears { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int EmploymentStatus { get; set; } = 1; // 1=Active, 2=Seconded, 3=Delegated, 4=OnLeave, 5=Terminated
    public bool IsActive { get; set; } = true;

    // Portal Access
    public bool CanLogin { get; set; }
    public string? PortalUsername { get; set; }
    public string? PortalPasswordHash { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public bool TwoFactorEnabled { get; set; }

    // Bank Details
    public string? BankName { get; set; }
    public string? BankIban { get; set; }

    // Verification
    public int VerificationStatus { get; set; } = 1; // 1=Pending, 2=Verified, 3=Rejected
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
    public virtual Department? Department { get; set; }

    // Child Navigation Collections (M3 Core)
    public virtual ICollection<AppointmentDecision> AppointmentDecisions { get; set; } = new List<AppointmentDecision>();
    public virtual ICollection<EmployeeDocument> Documents { get; set; } = new List<EmployeeDocument>();
    public virtual ICollection<EmployeeInventoryCustody> InventoryCustodies { get; set; } = new List<EmployeeInventoryCustody>();
    public virtual StaffCustodySummary? CustodySummary { get; set; }
    public virtual ICollection<EmployeeAttendance> Attendances { get; set; } = new List<EmployeeAttendance>();
    public virtual ICollection<TeacherSchedule> Schedules { get; set; } = new List<TeacherSchedule>();
    public virtual ICollection<EmployeePayroll> Payrolls { get; set; } = new List<EmployeePayroll>();
    public virtual ICollection<EmployeeLeave> Leaves { get; set; } = new List<EmployeeLeave>();
    public virtual ICollection<EmployeePerformanceReview> PerformanceReviews { get; set; } = new List<EmployeePerformanceReview>();
    public virtual ICollection<EmployeeViolation> Violations { get; set; } = new List<EmployeeViolation>();
    public virtual ICollection<EmployeeTraining> Trainings { get; set; } = new List<EmployeeTraining>();
    public virtual ICollection<EmployeeAdditionalTask> AdditionalTasks { get; set; } = new List<EmployeeAdditionalTask>();
    public virtual ICollection<SelfServicePortalRequest> SelfServiceRequests { get; set; } = new List<SelfServicePortalRequest>();
    public virtual ICollection<CommitteeMember> CommitteeMemberships { get; set; } = new List<CommitteeMember>();
    public virtual ICollection<MeetingAttendanceRecord> MeetingAttendances { get; set; } = new List<MeetingAttendanceRecord>();
    public virtual ICollection<EmployeeInternalTransfer> InternalTransfers { get; set; } = new List<EmployeeInternalTransfer>();
    public virtual ICollection<EmployeeExternalTransfer> ExternalTransfers { get; set; } = new List<EmployeeExternalTransfer>();
    public virtual ICollection<EmployeeTermination> Terminations { get; set; } = new List<EmployeeTermination>();

    // New Universal M3/M5 Financial Contracts & Transactions
    public virtual ICollection<EmployeePayrollFinancialContract> PayrollFinancialContracts { get; set; } = new List<EmployeePayrollFinancialContract>();
    public virtual ICollection<EmployeeFinancialTransaction> FinancialTransactions { get; set; } = new List<EmployeeFinancialTransaction>();

    // Cross-Module Navigation Collections (M1, M2, M4 Inter-Module Connectivity)
    public virtual ICollection<OfficialCircular> IssuedCirculars { get; set; } = new List<OfficialCircular>();
    public virtual ICollection<EducationalSupervisionVisit> ConductedSupervisionVisits { get; set; } = new List<EducationalSupervisionVisit>();
    public virtual ICollection<EducationalSupervisionVisit> ReceivedSupervisionVisits { get; set; } = new List<EducationalSupervisionVisit>();
    public virtual ICollection<Classroom> HomeroomClassrooms { get; set; } = new List<Classroom>();
    public virtual ICollection<ClassSchedule> TeachingSchedules { get; set; } = new List<ClassSchedule>();
    public virtual ICollection<StudentPsychologicalCounselingLog> ConductedCounselingSessions { get; set; } = new List<StudentPsychologicalCounselingLog>();
    public virtual ICollection<SchoolFacility> SupervisedFacilities { get; set; } = new List<SchoolFacility>();
    public virtual ICollection<InventoryItem> AssignedInventoryItems { get; set; } = new List<InventoryItem>();
    public virtual ICollection<SchoolAsset> AssignedAssets { get; set; } = new List<SchoolAsset>();
}
