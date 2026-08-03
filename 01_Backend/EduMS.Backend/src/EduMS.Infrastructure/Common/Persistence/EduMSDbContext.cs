using EduMS.Domain.Common;
using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduMS.Infrastructure.Common.Persistence;

public class EduMSDbContext(DbContextOptions<EduMSDbContext> options, EduMS.Application.Interfaces.Security.ICurrentUserService currentUserService) : DbContext(options)
{
    public long? CurrentSchoolId => currentUserService?.TenantId;

    // =========================================================
    #region M1 — School Administration
    // =========================================================
    public DbSet<AcademicBranchConfigLog> AcademicBranchConfigLogs => Set<AcademicBranchConfigLog>();
    public DbSet<AcademicLockPeriod> AcademicLockPeriods => Set<AcademicLockPeriod>();
    public DbSet<AcademicWarningPolicy> AcademicWarningPolicies => Set<AcademicWarningPolicy>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();
    public DbSet<ClassroomOperationalRule> ClassroomOperationalRules => Set<ClassroomOperationalRule>();
    public DbSet<ClassroomResourceAllocation> ClassroomResourceAllocations => Set<ClassroomResourceAllocation>();
    public DbSet<ClassSchedule> ClassSchedules => Set<ClassSchedule>();
    public DbSet<CurriculumTextbookDistribution> CurriculumTextbookDistributions => Set<CurriculumTextbookDistribution>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Directorate> Directorates => Set<Directorate>();
    public DbSet<DirectorateExamCenterAssignment> DirectorateExamCenterAssignments => Set<DirectorateExamCenterAssignment>();
    public DbSet<DirectorateLegalCaseLog> DirectorateLegalCaseLogs => Set<DirectorateLegalCaseLog>();
    public DbSet<DirectorateStatisticalReport> DirectorateStatisticalReports => Set<DirectorateStatisticalReport>();
    public DbSet<EducationalStage> EducationalStages => Set<EducationalStage>();
    public DbSet<EducationalSupervisionVisit> EducationalSupervisionVisits => Set<EducationalSupervisionVisit>();
    public DbSet<ExamDistributionTimetable> ExamDistributionTimetables => Set<ExamDistributionTimetable>();
    public DbSet<GradeCapacity> GradeCapacities => Set<GradeCapacity>();
    public DbSet<GradingScaleBound> GradingScaleBounds => Set<GradingScaleBound>();
    public DbSet<OfficialCircular> OfficialCirculars => Set<OfficialCircular>();
    public DbSet<ReferenceCodingLookup> ReferenceCodingLookups => Set<ReferenceCodingLookup>();
    public DbSet<School> Schools => Set<School>();
    public DbSet<SchoolAcademicYear> SchoolAcademicYears => Set<SchoolAcademicYear>();
    public DbSet<SchoolAccreditationLog> SchoolAccreditationLogs => Set<SchoolAccreditationLog>();
    public DbSet<SchoolAnnouncementLog> SchoolAnnouncementLogs => Set<SchoolAnnouncementLog>();
    public DbSet<SchoolAuditLog> SchoolAuditLogs => Set<SchoolAuditLog>();
    public DbSet<SchoolCanteenItem> SchoolCanteenItems => Set<SchoolCanteenItem>();
    public DbSet<SchoolContactInfo> SchoolContactInfos => Set<SchoolContactInfo>();
    public DbSet<SchoolCurriculumPlan> SchoolCurriculumPlans => Set<SchoolCurriculumPlan>();
    public DbSet<SchoolEventCalendar> SchoolEventCalendars => Set<SchoolEventCalendar>();
    public DbSet<SchoolFacility> SchoolFacilities => Set<SchoolFacility>();
    public DbSet<SchoolFacilityMaintenanceLog> SchoolFacilityMaintenanceLogs => Set<SchoolFacilityMaintenanceLog>();
    public DbSet<SchoolLevel> SchoolLevels => Set<SchoolLevel>();
    public DbSet<SchoolLibraryItem> SchoolLibraryItems => Set<SchoolLibraryItem>();
    public DbSet<SchoolOperationalBudgetLog> SchoolOperationalBudgetLogs => Set<SchoolOperationalBudgetLog>();
    public DbSet<SchoolSemester> SchoolSemesters => Set<SchoolSemester>();
    public DbSet<SchoolShift> SchoolShifts => Set<SchoolShift>();
    public DbSet<SchoolTransportationRoute> SchoolTransportationRoutes => Set<SchoolTransportationRoute>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<TrainingCourseOffering> TrainingCourseOfferings => Set<TrainingCourseOffering>();
    public DbSet<VisitorEntryLog> VisitorEntryLogs => Set<VisitorEntryLog>();
    #endregion

    // =========================================================
    #region M2 — Student Affairs
    // =========================================================
    public DbSet<AttendanceDetail> AttendanceDetails => Set<AttendanceDetail>();
    public DbSet<BehavioralLog> BehavioralLogs => Set<BehavioralLog>();
    public DbSet<ClassSection> ClassSections => Set<ClassSection>();
    public DbSet<DetailedAcademicWarningLog> DetailedAcademicWarningLogs => Set<DetailedAcademicWarningLog>();
    public DbSet<Guardian> Guardians => Set<Guardian>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<StudentAbsenceExcusal> StudentAbsenceExcusals => Set<StudentAbsenceExcusal>();
    public DbSet<StudentActivityParticipation> StudentActivityParticipations => Set<StudentActivityParticipation>();
    public DbSet<StudentAdmissionApplication> StudentAdmissionApplications => Set<StudentAdmissionApplication>();
    public DbSet<StudentAssessment> StudentAssessments => Set<StudentAssessment>();
    public DbSet<StudentAssignmentSubmission> StudentAssignmentSubmissions => Set<StudentAssignmentSubmission>();
    public DbSet<StudentAttachment> StudentAttachments => Set<StudentAttachment>();
    public DbSet<StudentCanteenPurchaseLog> StudentCanteenPurchaseLogs => Set<StudentCanteenPurchaseLog>();
    public DbSet<StudentComplaintLog> StudentComplaintLogs => Set<StudentComplaintLog>();
    public DbSet<StudentDailyAttendanceSummary> StudentDailyAttendanceSummaries => Set<StudentDailyAttendanceSummary>();
    public DbSet<StudentDisciplinaryHistory> StudentDisciplinaryHistories => Set<StudentDisciplinaryHistory>();
    public DbSet<StudentEnrollment> StudentEnrollments => Set<StudentEnrollment>();
    public DbSet<StudentExemplaryRecognition> StudentExemplaryRecognitions => Set<StudentExemplaryRecognition>();
    public DbSet<StudentExemption> StudentExemptions => Set<StudentExemption>();
    public DbSet<StudentExitClearance> StudentExitClearances => Set<StudentExitClearance>();
    public DbSet<StudentExtracurricularAchievement> StudentExtracurricularAchievements => Set<StudentExtracurricularAchievement>();
    public DbSet<StudentFinancialAidApplication> StudentFinancialAidApplications => Set<StudentFinancialAidApplication>();
    public DbSet<StudentGuardianRelationship> StudentGuardianRelationships => Set<StudentGuardianRelationship>();
    public DbSet<StudentHealthRecord> StudentHealthRecords => Set<StudentHealthRecord>();
    public DbSet<StudentIdentityDocument> StudentIdentityDocuments => Set<StudentIdentityDocument>();
    public DbSet<StudentInventoryCustody> StudentInventoryCustodies => Set<StudentInventoryCustody>();
    public DbSet<StudentLibraryBorrowingLog> StudentLibraryBorrowingLogs => Set<StudentLibraryBorrowingLog>();
    public DbSet<StudentMedicalAllergyLog> StudentMedicalAllergyLogs => Set<StudentMedicalAllergyLog>();
    public DbSet<StudentParentConferenceReservation> StudentParentConferenceReservations => Set<StudentParentConferenceReservation>();
    public DbSet<StudentPreviousAcademicHistory> StudentPreviousAcademicHistories => Set<StudentPreviousAcademicHistory>();
    public DbSet<StudentPsychologicalCounselingLog> StudentPsychologicalCounselingLogs => Set<StudentPsychologicalCounselingLog>();
    public DbSet<StudentSkillAndTalentRecord> StudentSkillAndTalentRecords => Set<StudentSkillAndTalentRecord>();
    public DbSet<StudentTransferLog> StudentTransferLogs => Set<StudentTransferLog>();
    public DbSet<StudentTransportationSubscription> StudentTransportationSubscriptions => Set<StudentTransportationSubscription>();
    public DbSet<StudentTransportPreference> StudentTransportPreferences => Set<StudentTransportPreference>();
    #endregion

    // =========================================================
    #region M3 — Employee Management
    // =========================================================
    public DbSet<AppointmentDecision> AppointmentDecisions => Set<AppointmentDecision>();
    public DbSet<CommitteeMember> CommitteeMembers => Set<CommitteeMember>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<EmployeeAttendance> EmployeeAttendances => Set<EmployeeAttendance>();
    public DbSet<EmployeeCommittee> EmployeeCommittees => Set<EmployeeCommittee>();
    public DbSet<EmployeeDocument> EmployeeDocuments => Set<EmployeeDocument>();
    public DbSet<EmployeeExternalTransfer> EmployeeExternalTransfers => Set<EmployeeExternalTransfer>();
    public DbSet<EmployeeFinancialTransaction> EmployeeFinancialTransactions => Set<EmployeeFinancialTransaction>();
    public DbSet<EmployeeInternalTransfer> EmployeeInternalTransfers => Set<EmployeeInternalTransfer>();
    public DbSet<EmployeeInventoryCustody> EmployeeInventoryCustodies => Set<EmployeeInventoryCustody>();
    public DbSet<EmployeeLeave> EmployeeLeaves => Set<EmployeeLeave>();
    public DbSet<EmployeeMeeting> EmployeeMeetings => Set<EmployeeMeeting>();
    public DbSet<EmployeeMentor> EmployeeMentors => Set<EmployeeMentor>();
    public DbSet<EmployeePayroll> EmployeePayrolls => Set<EmployeePayroll>();
    public DbSet<EmployeePayrollFinancialContract> EmployeePayrollFinancialContracts => Set<EmployeePayrollFinancialContract>();
    public DbSet<EmployeePerformanceReview> EmployeePerformanceReviews => Set<EmployeePerformanceReview>();
    public DbSet<EmployeeAdditionalTask> EmployeeAdditionalTasks => Set<EmployeeAdditionalTask>();
    public DbSet<EmployeeTermination> EmployeeTerminations => Set<EmployeeTermination>();
    public DbSet<EmployeeTraining> EmployeeTrainings => Set<EmployeeTraining>();
    public DbSet<EmployeeViolation> EmployeeViolations => Set<EmployeeViolation>();
    public DbSet<JobApplicant> JobApplicants => Set<JobApplicant>();
    public DbSet<MeetingAttendanceRecord> MeetingAttendanceRecords => Set<MeetingAttendanceRecord>();
    public DbSet<OrganizationalSector> OrganizationalSectors => Set<OrganizationalSector>();
    public DbSet<SelfServicePortalRequest> SelfServicePortalRequests => Set<SelfServicePortalRequest>();
    public DbSet<StaffCustodySummary> StaffCustodySummaries => Set<StaffCustodySummary>();
    public DbSet<TeacherSchedule> TeacherSchedules => Set<TeacherSchedule>();
    public DbSet<VacantPosition> VacantPositions => Set<VacantPosition>();
    #endregion

    // =========================================================
    #region M4 — Asset & Logistics
    // =========================================================
    public DbSet<AssetAllocation> AssetAllocations => Set<AssetAllocation>();
    public DbSet<AssetAssignment> AssetAssignments => Set<AssetAssignment>();
    public DbSet<AssetAuditFinalApproval> AssetAuditFinalApprovals => Set<AssetAuditFinalApproval>();
    public DbSet<AssetBudgetAllocation> AssetBudgetAllocations => Set<AssetBudgetAllocation>();
    public DbSet<AssetCategory> AssetCategories => Set<AssetCategory>();
    public DbSet<AssetComplianceAudit> AssetComplianceAudits => Set<AssetComplianceAudit>();
    public DbSet<AssetDepreciation> AssetDepreciations => Set<AssetDepreciation>();
    public DbSet<AssetDocument> AssetDocuments => Set<AssetDocument>();
    public DbSet<AssetExpense> AssetExpenses => Set<AssetExpense>();
    public DbSet<AssetFeasibilityComparison> AssetFeasibilityComparisons => Set<AssetFeasibilityComparison>();
    public DbSet<AssetFeasibilityRiskAnalysis> AssetFeasibilityRiskAnalyses => Set<AssetFeasibilityRiskAnalysis>();
    public DbSet<AssetFinancialAuditArchive> AssetFinancialAuditArchives => Set<AssetFinancialAuditArchive>();
    public DbSet<AssetFinancialSummaryReport> AssetFinancialSummaryReports => Set<AssetFinancialSummaryReport>();
    public DbSet<AssetFinancials> AssetFinancials => Set<AssetFinancials>();
    public DbSet<AssetInspectionLog> AssetInspectionLogs => Set<AssetInspectionLog>();
    public DbSet<AssetLocationRecord> AssetLocationRecords => Set<AssetLocationRecord>();
    public DbSet<AssetLoan> AssetLoans => Set<AssetLoan>();
    public DbSet<AssetLoanTrackingAlert> AssetLoanTrackingAlerts => Set<AssetLoanTrackingAlert>();
    public DbSet<AssetMaintenanceTicket> AssetMaintenanceTickets => Set<AssetMaintenanceTicket>();
    public DbSet<AssetMovementHistory> AssetMovementHistories => Set<AssetMovementHistory>();
    public DbSet<AssetReceiving> AssetReceivings => Set<AssetReceiving>();
    public DbSet<AssetRequirementRequest> AssetRequirementRequests => Set<AssetRequirementRequest>();
    public DbSet<AssetRevaluationImpairment> AssetRevaluationImpairments => Set<AssetRevaluationImpairment>();
    public DbSet<AssetStatusRecord> AssetStatusRecords => Set<AssetStatusRecord>();
    public DbSet<AssetSuspensionRequest> AssetSuspensionRequests => Set<AssetSuspensionRequest>();
    public DbSet<AssetTechnicalSpecification> AssetTechnicalSpecifications => Set<AssetTechnicalSpecification>();
    public DbSet<AssetTransferRequest> AssetTransferRequests => Set<AssetTransferRequest>();
    public DbSet<AssetUsageLog> AssetUsageLogs => Set<AssetUsageLog>();
    public DbSet<AssetWarrantyContract> AssetWarrantyContracts => Set<AssetWarrantyContract>();
    public DbSet<DepreciationTransaction> DepreciationTransactions => Set<DepreciationTransaction>();
    public DbSet<EducationalConsumableTracking> EducationalConsumableTrackings => Set<EducationalConsumableTracking>();
    public DbSet<FacilityDepartmentAssignment> FacilityDepartmentAssignments => Set<FacilityDepartmentAssignment>();
    public DbSet<FieldInventoryLog> FieldInventoryLogs => Set<FieldInventoryLog>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<InventoryPlan> InventoryPlans => Set<InventoryPlan>();
    public DbSet<InventoryReconciliation> InventoryReconciliations => Set<InventoryReconciliation>();
    public DbSet<MaintenanceExecution> MaintenanceExecutions => Set<MaintenanceExecution>();
    public DbSet<MaintenanceNotification> MaintenanceNotifications => Set<MaintenanceNotification>();
    public DbSet<MaintenanceSparePart> MaintenanceSpareParts => Set<MaintenanceSparePart>();
    public DbSet<PreventiveMaintenanceSchedule> PreventiveMaintenanceSchedules => Set<PreventiveMaintenanceSchedule>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<SchoolAsset> SchoolAssets => Set<SchoolAsset>();
    public DbSet<UsageViolation> UsageViolations => Set<UsageViolation>();
    public DbSet<Warehouse> Warehouses => Set<Warehouse>();
    #endregion

    // =========================================================
    #region M5 — Financial Management
    // =========================================================
    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<FeeInstallment> FeeInstallments => Set<FeeInstallment>();
    public DbSet<FeeInvoice> FeeInvoices => Set<FeeInvoice>();
    public DbSet<FeePayment> FeePayments => Set<FeePayment>();
    public DbSet<FeeStructure> FeeStructures => Set<FeeStructure>();
    public DbSet<FeeType> FeeTypes => Set<FeeType>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<JournalEntry> JournalEntries => Set<JournalEntry>();
    public DbSet<JournalEntryLine> JournalEntryLines => Set<JournalEntryLine>();
    public DbSet<PaymentVoucher> PaymentVouchers => Set<PaymentVoucher>();
    public DbSet<PayrollDetail> PayrollDetails => Set<PayrollDetail>();
    public DbSet<PayrollRun> PayrollRuns => Set<PayrollRun>();
    public DbSet<StudentAccount> StudentAccounts => Set<StudentAccount>();
    public DbSet<StudentInvoice> StudentInvoices => Set<StudentInvoice>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    #endregion

    // =========================================================
    #region M6 — Statistics & Reports
    // =========================================================
    public DbSet<ComparativeReport> ComparativeReports => Set<ComparativeReport>();
    public DbSet<DashboardKpiConfiguration> DashboardKpiConfigurations => Set<DashboardKpiConfiguration>();
    public DbSet<ExceptionalStatisticsReport> ExceptionalStatisticsReports => Set<ExceptionalStatisticsReport>();
    public DbSet<ExternalComplianceReport> ExternalComplianceReports => Set<ExternalComplianceReport>();
    public DbSet<GapAnalysisReport> GapAnalysisReports => Set<GapAnalysisReport>();
    public DbSet<KpiMetricRecord> KpiMetricRecords => Set<KpiMetricRecord>();
    public DbSet<ReportApproval> ReportApprovals => Set<ReportApproval>();
    public DbSet<SchoolFinancialSummaryReport> SchoolFinancialSummaryReports => Set<SchoolFinancialSummaryReport>();
    public DbSet<SchoolStatisticsDraft> SchoolStatisticsDrafts => Set<SchoolStatisticsDraft>();
    public DbSet<StatisticalReportSnapshot> StatisticalReportSnapshots => Set<StatisticalReportSnapshot>();
    public DbSet<StatisticsArchive> StatisticsArchives => Set<StatisticsArchive>();
    public DbSet<StatisticsReportsArchive> StatisticsReportsArchives => Set<StatisticsReportsArchive>();
    public DbSet<StatisticsUpdateHistory> StatisticsUpdateHistories => Set<StatisticsUpdateHistory>();
    public DbSet<SubmittedStatistics> SubmittedStatistics => Set<SubmittedStatistics>();
    public DbSet<SystemReport> SystemReports => Set<SystemReport>();
    public DbSet<TrendAnalysisResult> TrendAnalysisResults => Set<TrendAnalysisResult>();
    // --- Directorate Level (Office / Ministry reporting tier) ---
    public DbSet<DirectorateStatisticsSnapshot> DirectorateStatisticsSnapshots => Set<DirectorateStatisticsSnapshot>();
    public DbSet<OfficeReportSubmission> OfficeReportSubmissions => Set<OfficeReportSubmission>();
    #endregion

    // =========================================================
    #region M7 — Communication Management
    // =========================================================
    public DbSet<CommunicationTemplate> CommunicationTemplates => Set<CommunicationTemplate>();
    public DbSet<MessageQueue> MessageQueues => Set<MessageQueue>();
    public DbSet<SystemNotification> SystemNotifications => Set<SystemNotification>();
    #endregion

    // =========================================================
    #region M7 — Emergency Management
    // =========================================================
    public DbSet<CommunityPartnership> CommunityPartnerships => Set<CommunityPartnership>();
    public DbSet<EmergencyClosure> EmergencyClosures => Set<EmergencyClosure>();
    public DbSet<EmergencyHosting> EmergencyHostings => Set<EmergencyHosting>();
    public DbSet<EmergencyIncident> EmergencyIncidents => Set<EmergencyIncident>();
    public DbSet<EmergencyPlan> EmergencyPlans => Set<EmergencyPlan>();
    public DbSet<ExternalParticipation> ExternalParticipations => Set<ExternalParticipation>();
    public DbSet<RemediationPlan> RemediationPlans => Set<RemediationPlan>();
    public DbSet<SafetySecurityReport> SafetySecurityReports => Set<SafetySecurityReport>();
    public DbSet<SchoolAward> SchoolAwards => Set<SchoolAward>();
    public DbSet<SchoolDeficit> SchoolDeficits => Set<SchoolDeficit>();
    public DbSet<SchoolMerger> SchoolMergers => Set<SchoolMerger>();
    public DbSet<SchoolSurplus> SchoolSurpluses => Set<SchoolSurplus>();
    public DbSet<TransportationService> TransportationServices => Set<TransportationService>();
    #endregion

    // =========================================================
    #region M8 — Authentication & Users
    // =========================================================
    public DbSet<AccessPolicy> AccessPolicies => Set<AccessPolicy>();
    public DbSet<BehaviorPermission> BehaviorPermissions => Set<BehaviorPermission>();
    public DbSet<BehaviorPermissionMatrix> BehaviorPermissionMatrices => Set<BehaviorPermissionMatrix>();
    public DbSet<BehaviorPermissionRecord> BehaviorPermissionRecords => Set<BehaviorPermissionRecord>();
    public DbSet<GovernanceRbacRule> GovernanceRbacRules => Set<GovernanceRbacRule>();
    public DbSet<OfficePermission> OfficePermissions => Set<OfficePermission>();
    public DbSet<PermissionBaseModule> PermissionBaseModules => Set<PermissionBaseModule>();
    public DbSet<PermissionType> PermissionTypes => Set<PermissionType>();
    public DbSet<PrivilegeRule> PrivilegeRules => Set<PrivilegeRule>();
    public DbSet<RoleMatrix> RoleMatrices => Set<RoleMatrix>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<StudentAcademicPermission> StudentAcademicPermissions => Set<StudentAcademicPermission>();
    public DbSet<StudentBasePermission> StudentBasePermissions => Set<StudentBasePermission>();
    public DbSet<StudentFinancePermission> StudentFinancePermissions => Set<StudentFinancePermission>();
    public DbSet<StudentPermissionAuditLog> StudentPermissionAuditLogs => Set<StudentPermissionAuditLog>();
    public DbSet<SystemAuditLog> SystemAuditLogs => Set<SystemAuditLog>();
    public DbSet<SystemPermission> SystemPermissions => Set<SystemPermission>();
    public DbSet<SystemRole> SystemRoles => Set<SystemRole>();
    public DbSet<SystemUser> SystemUsers => Set<SystemUser>();
    public DbSet<UserActivityLog> UserActivityLogs => Set<UserActivityLog>();
    public DbSet<UserDirectPermission> UserDirectPermissions => Set<UserDirectPermission>();
    public DbSet<UserRoleAssignment> UserRoleAssignments => Set<UserRoleAssignment>();
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =========================================================
        // GLOBAL QUERY FILTERS
        // Strategy: Apply SchoolId multi-tenancy filter to all entities that
        // have a SchoolId property, EXCEPT:
        // 1. Entities mapped to SQL Views (ToView) — EF Core does not support
        //    query filters on keyless view entities reliably.
        // 2. Cross-school/Directorate entities that are intentionally school-agnostic.
        // 3. System-level lookup/config entities (Roles, Permissions, etc.).
        // =========================================================

        // Entities explicitly EXEMPTED from the SchoolId query filter
        var schoolIdFilterExemptions = new HashSet<Type>
        {
            // --- SQL View entities (ToView) — no physical table, filter not applicable ---
            typeof(SchoolFinancialSummaryReport),
            typeof(GapAnalysisReport),

            // --- Cross-school / Directorate-level entities ---
            typeof(DirectorateStatisticsSnapshot),  // Groups ALL schools under a directorate
            typeof(OfficeReportSubmission),          // Office-level, not school-scoped

            // --- M1: System/Office-level entities that span all schools ---
            typeof(Directorate),
            typeof(DirectorateStatisticalReport),
            typeof(DirectorateExamCenterAssignment),
            typeof(DirectorateLegalCaseLog),
            typeof(ReferenceCodingLookup),
            typeof(EducationalStage),

            // --- M8: System-wide auth/security (no SchoolId by design) ---
            typeof(SystemUser),
            typeof(SystemRole),
            typeof(SystemPermission),
            typeof(SystemAuditLog),
            typeof(UserRoleAssignment),
            typeof(UserDirectPermission),
            typeof(RolePermission),
            typeof(AccessPolicy),
            typeof(PermissionType),
            typeof(PermissionBaseModule),
            typeof(GovernanceRbacRule),
            typeof(PrivilegeRule),
        };

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Skip derived types (handled by base type filter)
            if (entityType.BaseType != null) continue;

            // Skip explicitly exempted types
            if (schoolIdFilterExemptions.Contains(entityType.ClrType)) continue;

            // Skip keyless entity types (Views mapped with ToView + no key)
            if (entityType.IsKeyless) continue;
            var schoolIdProperty = entityType.FindProperty("SchoolId");
            if (schoolIdProperty == null) continue;

            // Build the filter expression dynamically for both long? and long SchoolId types
            var parameter = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
            var currentSchoolIdProp = System.Linq.Expressions.Expression.Property(
                System.Linq.Expressions.Expression.Constant(this), nameof(CurrentSchoolId));

            System.Linq.Expressions.Expression property;
            if (schoolIdProperty.ClrType == typeof(long))
            {
                // long -> convert to long? for comparison
                property = System.Linq.Expressions.Expression.Convert(
                    System.Linq.Expressions.Expression.Property(parameter, schoolIdProperty.PropertyInfo!),
                    typeof(long?));
            }
            else
            {
                // long? -> use directly
                property = System.Linq.Expressions.Expression.Property(parameter, schoolIdProperty.PropertyInfo!);
            }

            // Filter: e.SchoolId == CurrentSchoolId || CurrentSchoolId == null
            var equals = System.Linq.Expressions.Expression.Equal(property, currentSchoolIdProp);
            var isNull = System.Linq.Expressions.Expression.Equal(
                currentSchoolIdProp, System.Linq.Expressions.Expression.Constant(null, typeof(long?)));
            var orElse = System.Linq.Expressions.Expression.OrElse(equals, isNull);

            entityType.SetQueryFilter(System.Linq.Expressions.Expression.Lambda(orElse, parameter));
        }

        // Apply all EF Core Fluent API configurations from this assembly automatically
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduMSDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseAuditableEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTimeOffset.UtcNow;
                entry.Entity.VersionToken = Guid.NewGuid();
                entry.Entity.SyncStatus = Domain.Enums.SyncStatus.Pending;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.ModifiedAt = DateTimeOffset.UtcNow;
                entry.Entity.VersionToken = Guid.NewGuid();
                entry.Entity.SyncStatus = Domain.Enums.SyncStatus.Pending;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
