using System;
using System.Collections.Generic;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

// ============================================================
//  EduMS – Grand 8-Module Relational Cross-Linking Layer
//  Phase-2: Cross-Module Relational Integration & Final Schema
//  Consolidation.  All entities in this file are pure bridge /
//  linking records.  Each one owns its own primitive FK fields
//  (long) and virtual navigation properties to preserve full
//  EF Core lazy-loading proxy compatibility and Oracle 19c
//  byte-target alignment.
// ============================================================

// ─────────────────────────────────────────────────────────────
//  BRIDGE 1 – M2 (Student Affairs) ⟷ M5 (Financial Management)
//  Links student enrollments to financial accounts and invoices.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر الحساب المالي للتسجيل الأكاديمي -  يربط كل تسجيل أكاديمي
/// (StudentEnrollment) بحسابه المالي الرئيسي (StudentAccount).
/// يضمن وجود سجل ربط موثق بين النشاط الأكاديمي والذمم المالية.
/// M2 ⟷ M5 Bridge.
/// </summary>
public class EnrollmentFinancialLink : BaseAuditableEntity
{
    public long EnrollmentId { get; set; }       // FK → StudentEnrollment
    public long StudentAccountId { get; set; }   // FK → StudentAccount
    public long StudentId { get; set; }           // Denormalized for fast queries
    public long SchoolId { get; set; }
    public long? SchoolAcademicYearId { get; set; }
    public decimal TuitionFeeDue { get; set; }   // الرسوم المستحقة عن هذا التسجيل
    public decimal DiscountApplied { get; set; }
    public decimal ExemptionApplied { get; set; }
    public decimal NetPayable { get; set; }
    public bool IsSettled { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? Notes { get; set; }

    public virtual StudentEnrollment? Enrollment { get; set; }
    public virtual StudentAccount? StudentAccount { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

/// <summary>
/// جسر الإيصال الأكاديمي-المالي - يربط كل إيصال دفع (PaymentVoucher)
/// بالفاتورة المدرسية (FeeInvoice) والتسجيل الأكاديمي المقابل.
/// M2 ⟷ M5 Payment Settlement Bridge.
/// </summary>
public class PaymentToInvoiceSettlement : BaseAuditableEntity
{
    public long PaymentVoucherId { get; set; }   // FK → PaymentVoucher (M5)
    public long FeeInvoiceId { get; set; }        // FK → FeeInvoice (M5)
    public long StudentId { get; set; }           // FK → Student (M2)
    public long SchoolId { get; set; }
    public decimal AllocatedAmount { get; set; }  // المبلغ المُخصَّص من هذا الإيصال لهذه الفاتورة
    public string? Notes { get; set; }

    public virtual PaymentVoucher? PaymentVoucher { get; set; }
    public virtual FeeInvoice? FeeInvoice { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 2 – M3 (Employee Management) ⟷ M5 (Financial Management)
//  Links employee payroll details to financial journal entries.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر كشف الرواتب - القيد اليومي - يربط كل سطر راتب موظف
/// (PayrollDetail) بالقيد المحاسبي المقابل (JournalEntry) في M5.
/// M3 ⟷ M5 Payroll ↔ Ledger Bridge.
/// </summary>
public class PayrollJournalEntryLink : BaseAuditableEntity
{
    public long PayrollDetailId { get; set; }    // FK → PayrollDetail (M5)
    public long JournalEntryId { get; set; }      // FK → JournalEntry (M5)
    public long EmployeeId { get; set; }          // FK → Employee (M3)
    public long PayrollRunId { get; set; }        // FK → PayrollRun (M5)
    public decimal SalaryAmount { get; set; }     // صافي الراتب المُقيَّد
    public string? Notes { get; set; }

    public virtual PayrollDetail? PayrollDetail { get; set; }
    public virtual JournalEntry? JournalEntry { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual PayrollRun? PayrollRun { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 3 – M4 (Asset & Logistics) ⟷ M5 (Financial Management)
//  Connects asset procurement and depreciation to journal entries.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر الأصول - القيد المحاسبي - يربط كل أصل مدرسي (SchoolAsset)
/// بقيوده المحاسبية في دفتر الأستاذ العام (JournalEntry) لتتبع
/// الاستهلاك والإيرادات والمصاريف المرتبطة بالأصول.
/// M4 ⟷ M5 Asset Depreciation / Capitalization Bridge.
/// </summary>
public class AssetFinancialJournalLink : BaseAuditableEntity
{
    public long SchoolAssetId { get; set; }      // FK → SchoolAsset (M4)
    public long JournalEntryId { get; set; }      // FK → JournalEntry (M5)
    public long SchoolId { get; set; }
    public string EntryType { get; set; } = string.Empty; // Acquisition, Depreciation, Disposal, Revaluation, Insurance
    public decimal EntryAmount { get; set; }
    public DateTime EntryDate { get; set; }
    public string? Notes { get; set; }

    public virtual SchoolAsset? SchoolAsset { get; set; }
    public virtual JournalEntry? JournalEntry { get; set; }
    public virtual School? School { get; set; }
}

/// <summary>
/// جسر أصول مشتريات المدرسة - يربط أوامر الشراء (PurchaseOrder)
/// بسندات الصرف (PaymentVoucher) في M5.
/// M4 ⟷ M5 Procurement Payment Bridge.
/// </summary>
public class AssetProcurementPaymentLink : BaseAuditableEntity
{
    public long PurchaseOrderId { get; set; }      // FK → PurchaseOrder (M4)
    public long PaymentVoucherId { get; set; }     // FK → PaymentVoucher (M5)
    public long SchoolId { get; set; }
    public decimal PaidAmount { get; set; }
    public string? Notes { get; set; }

    public virtual PurchaseOrder? PurchaseOrder { get; set; }
    public virtual PaymentVoucher? PaymentVoucher { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 4 – M7 (Emergency) ⟷ M4 (Asset & Logistics)
//  Maps emergency incidents to affected/deployed assets.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر الأصول المتأثرة بالطوارئ - يربط كل حادثة طارئة
/// (EmergencyIncident) بالأصول المدرسية التي تضررت أو نُشرت
/// أثناء الاستجابة للطوارئ.
/// M7 ⟷ M4 Emergency Asset Deployment Bridge.
/// </summary>
public class EmergencyIncidentAssetImpact : BaseAuditableEntity
{
    public long EmergencyIncidentId { get; set; }  // FK → EmergencyIncident (M7)
    public long SchoolAssetId { get; set; }         // FK → SchoolAsset (M4)
    public long SchoolId { get; set; }
    public int ImpactType { get; set; }             // 1=Damaged, 2=Destroyed, 3=Deployed, 4=Confiscated, 5=LostContact
    public decimal EstimatedDamageValue { get; set; }
    public string? DamageDescription { get; set; }
    public bool RequiresMaintenance { get; set; }
    public long? MaintenanceTicketId { get; set; } // FK → AssetMaintenanceTicket (M4)
    public string? Notes { get; set; }

    public virtual EmergencyIncident? EmergencyIncident { get; set; }
    public virtual SchoolAsset? SchoolAsset { get; set; }
    public virtual School? School { get; set; }
    public virtual AssetMaintenanceTicket? MaintenanceTicket { get; set; }
}

/// <summary>
/// جسر مخزن الطوارئ - يربط الاستضافة الطارئة (EmergencyHosting)
/// بالمستودعات (Warehouse) والمخزون المستخدم في الطوارئ.
/// M7 ⟷ M4 Emergency Supply/Warehouse Bridge.
/// </summary>
public class EmergencyHostingWarehouseLink : BaseAuditableEntity
{
    public long EmergencyHostingId { get; set; }   // FK → EmergencyHosting (M7)
    public long WarehouseId { get; set; }           // FK → Warehouse (M4)
    public long SchoolId { get; set; }
    public string? SuppliesUsedJson { get; set; }  // JSON list of inventory items consumed
    public decimal TotalSupplyValue { get; set; }
    public string? Notes { get; set; }

    public virtual EmergencyHosting? EmergencyHosting { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 5 – M7 (Emergency) ⟷ M5 (Financial Management)
//  Connects emergency expenses and damage costs to M5 journals.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر التكاليف المالية للطوارئ - يربط أي حادثة طارئة أو إغلاق
/// أو استضافة طارئة بالقيود المحاسبية في M5 لتتبع مصاريف
/// الطوارئ بدقة عالية.
/// M7 ⟷ M5 Emergency Cost Ledger Bridge.
/// </summary>
public class EmergencyFinancialExpenseLink : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long? EmergencyIncidentId { get; set; }  // FK → EmergencyIncident (M7) – nullable if closure
    public long? EmergencyHostingId { get; set; }   // FK → EmergencyHosting (M7)  – nullable if incident
    public long? EmergencyClosureId { get; set; }   // FK → EmergencyClosure (M7)  – nullable if hosting
    public long JournalEntryId { get; set; }         // FK → JournalEntry (M5)
    public decimal ExpenseAmount { get; set; }
    public string ExpenseCategory { get; set; } = string.Empty; // PropertyRepair, MedicalAid, Transport, Security, Supply
    public string? Notes { get; set; }

    public virtual EmergencyIncident? EmergencyIncident { get; set; }
    public virtual EmergencyHosting? EmergencyHosting { get; set; }
    public virtual EmergencyClosure? EmergencyClosure { get; set; }
    public virtual JournalEntry? JournalEntry { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 6 – M8 (Auth & RBAC) ⟷ M3 / M2 / M1 identity anchors
//  Cleanly links SystemUser identity to M3 Employee, M2 Student /
//  Guardian, and M1 School / Directorate context.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر هوية المستخدم - الموظف - يربط SystemUser (M8) بسجل الموظف
/// (Employee M3) بعلاقة واحد-لواحد مدعومة بالتدقيق المحاسبي.
/// يضمن أن لكل حساب مستخدم نشط موظفاً حقيقياً وراءه.
/// M8 ⟷ M3 User–Employee Identity Link.
/// </summary>
public class UserEmployeeIdentityLink : BaseAuditableEntity
{
    public long SystemUserId { get; set; }        // FK → SystemUser (M8)
    public long EmployeeId { get; set; }           // FK → Employee (M3)
    public long SchoolId { get; set; }
    public long? DirectorateId { get; set; }       // FK → Directorate (M1) for office staff
    public long? OrganizationalSectorId { get; set; } // FK → OrganizationalSector (M3)
    public int LinkStatus { get; set; } = 1;       // 1=Active, 2=Suspended, 3=Terminated
    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UnlinkedAt { get; set; }
    public string? UnlinkReason { get; set; }
    public long? LinkedByUserId { get; set; }
    public string? Notes { get; set; }

    public virtual SystemUser? SystemUser { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
    public virtual Directorate? Directorate { get; set; }
    public virtual OrganizationalSector? OrganizationalSector { get; set; }
}

/// <summary>
/// جسر هوية المستخدم - الطالب - يربط SystemUser (M8) بسجل الطالب
/// (Student M2) لتفعيل البوابة الطلابية بتوثيق مؤسسي موثوق.
/// M8 ⟷ M2 User–Student Identity Link.
/// </summary>
public class UserStudentIdentityLink : BaseAuditableEntity
{
    public long SystemUserId { get; set; }        // FK → SystemUser (M8)
    public long StudentId { get; set; }            // FK → Student (M2)
    public long SchoolId { get; set; }
    public int LinkStatus { get; set; } = 1;       // 1=Active, 2=Graduated, 3=Withdrawn, 4=Suspended
    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UnlinkedAt { get; set; }
    public long? LinkedByUserId { get; set; }
    public string? Notes { get; set; }

    public virtual SystemUser? SystemUser { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

/// <summary>
/// جسر هوية المستخدم - ولي الأمر - يربط SystemUser (M8) بعلاقة
/// الولاية (StudentGuardianRelationship M2) لتمكين بوابة أولياء الأمور.
/// M8 ⟷ M2 User–Guardian Identity Link.
/// </summary>
public class UserGuardianIdentityLink : BaseAuditableEntity
{
    public long SystemUserId { get; set; }                 // FK → SystemUser (M8)
    public long StudentGuardianRelationshipId { get; set; } // FK → StudentGuardianRelationship (M2)
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public int LinkStatus { get; set; } = 1;               // 1=Active, 2=Revoked
    public DateTime LinkedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UnlinkedAt { get; set; }
    public string? Notes { get; set; }

    public virtual SystemUser? SystemUser { get; set; }
    public virtual StudentGuardianRelationship? GuardianRelationship { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 7 – M6 (Statistics & Reports) ⟷ M1-M5 Data Sources
//  Links statistical snapshots to originating modules for
//  reproducible analytics.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر لقطة التقرير الإحصائي - يربط كل لقطة إحصائية
/// (StatisticalReportSnapshot M6) بالوحدات الأصلية التي
/// استُمدت منها البيانات، مما يمكّن التدقيق الأثري للتقارير.
/// M6 ⟷ M1-M5 Analytics Source Traceability Bridge.
/// </summary>
public class ReportSnapshotSourceLink : BaseAuditableEntity
{
    public long StatisticalReportSnapshotId { get; set; }  // FK → StatisticalReportSnapshot (M6)
    public long SchoolId { get; set; }
    public string SourceModule { get; set; } = string.Empty;  // M1, M2, M3, M4, M5, M7
    public string SourceEntityType { get; set; } = string.Empty;  // Student, Employee, SchoolAsset, FeeInvoice
    public long? SourceEntityId { get; set; }                    // Optional specific entity ID
    public long? SchoolAcademicYearId { get; set; }
    public string? AggregationDescription { get; set; }
    public string? Notes { get; set; }

    public virtual StatisticalReportSnapshot? StatisticalReportSnapshot { get; set; }
    public virtual School? School { get; set; }
}

/// <summary>
/// جسر تدريب الموظف - الدورة التدريبية - يربط دورات التدريب الرسمية
/// (EmployeeTraining M3) بعروض المساقات التدريبية في M1
/// (TrainingCourseOffering) لتوحيد سجلات التطوير المهني.
/// M3 ⟷ M1 Training–Offering Synchronization Bridge.
/// </summary>
public class EmployeeTrainingCourseLink : BaseAuditableEntity
{
    public long EmployeeTrainingId { get; set; }         // FK → EmployeeTraining (M3)
    public long TrainingCourseOfferingId { get; set; }   // FK → TrainingCourseOffering (M1)
    public long EmployeeId { get; set; }
    public long SchoolId { get; set; }
    public decimal TrainingFeeAmount { get; set; }        // تكلفة التدريب لكل موظف
    public string? FundingSource { get; set; }            // Internal, MoE, External
    public bool CertificateIssued { get; set; }
    public string? CertificateUrl { get; set; }
    public string? Notes { get; set; }

    public virtual EmployeeTraining? EmployeeTraining { get; set; }
    public virtual TrainingCourseOffering? TrainingCourseOffering { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 8 – M7 (Emergency) ⟷ M2 (Student Affairs)
//  Tracks student attendance/safety status during emergencies.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر سلامة الطالب في الطوارئ - يتتبع حالة سلامة كل طالب
/// (Student M2) أثناء حادثة طارئة (EmergencyIncident M7)،
/// مما يضمن محاسبة الحضور الفوري وإبلاغ أولياء الأمور.
/// M7 ⟷ M2 Emergency Student Safety Tracking Bridge.
/// </summary>
public class EmergencyStudentSafetyRecord : BaseAuditableEntity
{
    public long EmergencyIncidentId { get; set; }  // FK → EmergencyIncident (M7)
    public long StudentId { get; set; }             // FK → Student (M2)
    public long SchoolId { get; set; }
    public int SafetyStatus { get; set; } = 1;      // 1=Safe, 2=Injured, 3=MissingContact, 4=Evacuated, 5=Hospitalized
    public bool ParentNotified { get; set; }
    public DateTime? ParentNotificationTime { get; set; }
    public string? Location { get; set; }           // Current confirmed location
    public string? Notes { get; set; }

    public virtual EmergencyIncident? EmergencyIncident { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

/// <summary>
/// جسر سلامة الموظف في الطوارئ - يتتبع حالة سلامة كل موظف
/// (Employee M3) أثناء حادثة طارئة (EmergencyIncident M7).
/// M7 ⟷ M3 Emergency Employee Safety Tracking Bridge.
/// </summary>
public class EmergencyEmployeeSafetyRecord : BaseAuditableEntity
{
    public long EmergencyIncidentId { get; set; }  // FK → EmergencyIncident (M7)
    public long EmployeeId { get; set; }            // FK → Employee (M3)
    public long SchoolId { get; set; }
    public int SafetyStatus { get; set; } = 1;      // 1=Safe, 2=Injured, 3=MissingContact, 4=Evacuated, 5=OnDuty
    public bool IsOnDutyDuringIncident { get; set; }
    public string? AssignedRole { get; set; }        // FireMarshal, FirstAider, SecurityOfficer, CommunicationsOfficer
    public string? Notes { get; set; }

    public virtual EmergencyIncident? EmergencyIncident { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 9 – M2 (Student) ⟷ M4 (Asset/Inventory) custody
//  Unifies student inventory borrowings with asset ledger.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر عهدة الطالب - الأصل - يربط عهدة الطالب (StudentInventoryCustody M2)
/// بالأصل المحدد (SchoolAsset M4) أو عنصر المخزون (InventoryItem M4)
/// بدلاً من تكرار بيانات الأصل.
/// M2 ⟷ M4 Student Custody–Asset Registration Bridge.
/// </summary>
public class StudentCustodyAssetLink : BaseAuditableEntity
{
    public long StudentInventoryCustodyId { get; set; }  // FK → StudentInventoryCustody (M2)
    public long? SchoolAssetId { get; set; }              // FK → SchoolAsset (M4) – if fixed asset
    public long? InventoryItemId { get; set; }            // FK → InventoryItem (M4) – if consumable
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public decimal ReplacementValue { get; set; }         // قيمة الاستبدال عند الفقدان
    public bool IsReturned { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int ConditionOnReturn { get; set; } // 1=Good, 2=Damaged, 3=Lost
    public string? Notes { get; set; }

    public virtual StudentInventoryCustody? StudentInventoryCustody { get; set; }
    public virtual SchoolAsset? SchoolAsset { get; set; }
    public virtual InventoryItem? InventoryItem { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 10 – M7 (Transportation) ⟷ M2 (Student Transport)
//  Links M7 transportation service routes to student transport
//  subscriptions in M2.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر اشتراك الطالب في خط النقل - يربط اشتراك الطالب في النقل
/// (StudentTransportationSubscription M2) بخط النقل الفعلي
/// (TransportationService M7) لتوحيد بيانات أسطول الحافلات.
/// M2 ⟷ M7 Student Transport Subscription–Route Bridge.
/// </summary>
public class StudentTransportRouteLink : BaseAuditableEntity
{
    public long StudentTransportationSubscriptionId { get; set; } // FK → StudentTransportationSubscription (M2)
    public long TransportationServiceId { get; set; }              // FK → TransportationService (M7)
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public string? AssignedSeatNumber { get; set; }
    public int SubscriptionStatus { get; set; } = 1; // 1=Active, 2=Suspended, 3=Cancelled
    public DateTime? EffectiveFrom { get; set; }
    public DateTime? EffectiveTo { get; set; }
    public string? Notes { get; set; }

    public virtual StudentTransportationSubscription? StudentTransportationSubscription { get; set; }
    public virtual TransportationService? TransportationService { get; set; }
    public virtual Student? Student { get; set; }
    public virtual School? School { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 11 – M8 (SystemAuditLog) ⟷ All Modules
//  Provides a polymorphic entity-tag resolver for audit trail.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// قاموس تعريف الكيانات القابلة للتدقيق - سجل مركزي لكل كيان في
/// النظام قابل للتدقيق عبر SystemAuditLog (M8). يُستخدم للتحقق
/// من صحة EntityType/EntityId في سجل التدقيق ويوفر وصفاً قابلاً
/// للقراءة لكل نوع كيان عبر الأقسام الثمانية.
/// M8 ⟷ All Modules Audit-Entity Registry.
/// </summary>
public class AuditableEntityRegistry : BaseAuditableEntity
{
    public string EntityTypeKey { get; set; } = string.Empty; // e.g. "Student", "Employee", "SchoolAsset"
    public string SourceModule { get; set; } = string.Empty;  // M1, M2, M3, M4, M5, M6, M7, M8
    public string TableNameHint { get; set; } = string.Empty; // Actual DB table name for tracing
    public string EntityNameAr { get; set; } = string.Empty;
    public string? EntityNameEn { get; set; }
    public bool IsSensitive { get; set; }                     // Requires elevated audit logging
    public bool RequiresApprovalToModify { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 12 – M6 (KPI Metrics) ⟷ M5 Financial
//  Links KPI metric records to financial journal periods.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// جسر المؤشرات المالية - يربط كل قيمة لمؤشر أداء مالي
/// (KpiMetricRecord M6) بفترة دفتر الأستاذ المرجعية في M5
/// لضمان الاتساق بين لوحة التحكم التحليلية والسجلات المحاسبية.
/// M6 ⟷ M5 KPI–Financial Period Alignment Bridge.
/// </summary>
public class KpiFinancialPeriodLink : BaseAuditableEntity
{
    public long KpiMetricRecordId { get; set; }  // FK → KpiMetricRecord (M6)
    public long? PayrollRunId { get; set; }       // FK → PayrollRun (M5) – for payroll KPIs
    public long? JournalEntryId { get; set; }     // FK → JournalEntry (M5) – for budget KPIs
    public long SchoolId { get; set; }
    public string PeriodLabel { get; set; } = string.Empty; // e.g. "2025-Q3"
    public string? Notes { get; set; }

    public virtual KpiMetricRecord? KpiMetricRecord { get; set; }
    public virtual PayrollRun? PayrollRun { get; set; }
    public virtual JournalEntry? JournalEntry { get; set; }
    public virtual School? School { get; set; }
}
