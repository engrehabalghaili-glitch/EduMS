using System;
using System.Collections.Generic;
using EduMS.Domain.Common;

namespace EduMS.Domain.Entities;

/// <summary>
/// نشاط المستخدم وسجل تتبع الجلسات - extracted from ZIP ERD UserActivityLog (lines 8498-8518).
/// Designed for high-throughput session tracking and read-only immutable logging.
/// </summary>
public class UserActivityLog : BaseAuditableEntity
{
    public long UserId { get; set; }
    public long? SchoolId { get; set; }
    public string ActivityType { get; set; } = string.Empty; // Login, Logout, FailedLogin, PasswordChange, DataEdit
    public DateTime ActivityTimestamp { get; set; } = DateTime.UtcNow;
    public int ActivityStatus { get; set; } // 1=Success, 2=Failed, 3=Blocked
    public string? FailureReason { get; set; }
    public string? IpAddress { get; set; }
    public string? DeviceType { get; set; } // Desktop, Mobile, Tablet
    public string? DeviceName { get; set; }
    public string? OperatingSystem { get; set; }
    public string? Browser { get; set; }
    public string? UserAgent { get; set; }
    public string? LocationText { get; set; }
    public string? SessionId { get; set; }
    public string? ActionDetailsJson { get; set; }
    public string? Notes { get; set; }

    public virtual SystemUser? User { get; set; }
}

/// <summary>
/// نوع الصلاحية - extracted from ZIP ERD PermissionType (lines 8520-8540).
/// </summary>
public class PermissionType : BaseAuditableEntity
{
    public string TypeCode { get; set; } = string.Empty; // VIEW, CREATE, EDIT, DELETE, APPROVE
    public string TypeNameAr { get; set; } = string.Empty;
    public string? TypeNameEn { get; set; }
    public string? Category { get; set; } // View, Create, Edit, Delete, Approve, Export, Print
    public string? ScopeType { get; set; } // Own, All, Department, School
    public string? RiskLevel { get; set; } // Low, Medium, High, Critical
    public bool RequiresApproval { get; set; }
    public string? ApprovalLevel { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsSystem { get; set; }
    public int SortOrder { get; set; }
}

/// <summary>
/// الصلاحية الفردية في النظام - extracted from ZIP ERD Permission (lines 8542-8564).
/// Uses custom string permission keys rather than fragmented enums.
/// </summary>
public class SystemPermission : BaseAuditableEntity
{
    public string PermissionKey { get; set; } = string.Empty; // e.g. students.create, finance.invoice.exempt
    public string Module { get; set; } = string.Empty; // Student, Finance, Employee, Asset, Report, Settings
    public string? SubModule { get; set; } // Enrollment, Grades, Attendance
    public string? ActionType { get; set; } // view, create, edit, delete, approve, export, print, import
    public long? PermissionTypeId { get; set; }
    public string? DefaultScope { get; set; } // Own, Department, School, All
    public string NameAr { get; set; } = string.Empty;
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? RiskLevel { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresLogging { get; set; }
    public string? ConditionsJson { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual PermissionType? PermissionType { get; set; }
}

/// <summary>
/// الدور في النظام مع التسلسل الهرمي - extracted from ZIP ERD Role (lines 8566-8585).
/// </summary>
public class SystemRole : BaseAuditableEntity
{
    public string RoleCode { get; set; } = string.Empty; // SCHOOL_PRINCIPAL, TEACHER, FINANCE_MANAGER
    public string RoleNameAr { get; set; } = string.Empty;
    public string? RoleNameEn { get; set; }
    public int RoleType { get; set; } // 1=System, 2=School, 3=Office, 4=Temporary
    public int HierarchyLevel { get; set; } = 1; // 1=Highest
    public long? ParentRoleId { get; set; }
    public bool IsInheritable { get; set; }
    public bool IsAssignable { get; set; } = true;
    public bool IsSystem { get; set; }
    public bool IsActive { get; set; } = true;
    public string? DescriptionAr { get; set; }

    public virtual SystemRole? ParentRole { get; set; }
}

/// <summary>
/// ربط الصلاحية بالدور - extracted from ZIP ERD RolePermission (lines 8587-8603).
/// </summary>
public class RolePermission : BaseAuditableEntity
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }
    public string? ScopeOverride { get; set; }
    public bool IsInherited { get; set; }
    public long? InheritedFromRoleId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? GrantedByUserId { get; set; }
    public DateTime? GrantedAt { get; set; }
    public string? Notes { get; set; }

    public virtual SystemRole? Role { get; set; }
    public virtual SystemPermission? Permission { get; set; }
}

/// <summary>
/// تعيين الدور لمستخدم - extracted from ZIP ERD UserRole (lines 8605-8621).
/// </summary>
public class UserRoleAssignment : BaseAuditableEntity
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
    public long? SchoolId { get; set; }
    public bool IsPrimary { get; set; }
    public string? ScopeContextJson { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsActive { get; set; } = true;
    public long? AssignedByUserId { get; set; }
    public DateTime? AssignedAt { get; set; }
    public string? Notes { get; set; }

    public virtual SystemUser? User { get; set; }
    public virtual SystemRole? Role { get; set; }
}

/// <summary>
/// حوكمة الأدوار والصلاحيات - extracted from ZIP ERD GovernanceRBAC (lines 8623-8638).
/// </summary>
public class GovernanceRbacRule : BaseAuditableEntity
{
    public long RoleId { get; set; }
    public long? TargetRoleId { get; set; }
    public long? TargetPermissionId { get; set; }
    public string AllowedAction { get; set; } = string.Empty; // grant, revoke, modify, view
    public bool CanDelegate { get; set; }
    public bool ApprovalRequired { get; set; }
    public long? ApprovalRoleId { get; set; }
    public string? Notes { get; set; }

    public virtual SystemRole? Role { get; set; }
}

/// <summary>
/// الصلاحية المباشرة على المستخدم (Override للدور) - extracted from ZIP ERD UserPermission (lines 8640-8656).
/// </summary>
public class UserDirectPermission : BaseAuditableEntity
{
    public long UserId { get; set; }
    public long PermissionId { get; set; }
    public long? SchoolId { get; set; }
    public string? ScopeOverride { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? GrantedByUserId { get; set; }
    public DateTime? GrantedAt { get; set; }
    public string? Reason { get; set; }
    public string? Notes { get; set; }

    public virtual SystemUser? User { get; set; }
    public virtual SystemPermission? Permission { get; set; }
}

/// <summary>
/// سياسات الوصول (زمنية/مكانية/جهاز) - extracted from ZIP ERD AccessPolicy (lines 8658-8678).
/// </summary>
public class AccessPolicy : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public string PolicyCode { get; set; } = string.Empty;
    public string PolicyNameAr { get; set; } = string.Empty;
    public string? PolicyNameEn { get; set; }
    public int PolicyType { get; set; } // 1=Time, 2=Location, 3=Device, 4=IpAddress
    public string? PolicyRuleJson { get; set; }
    public int PolicyEffect { get; set; } // 1=Allow, 2=Deny, 3=RequireAdditionalApproval
    public int Priority { get; set; } = 50;
    public string? AppliesToType { get; set; } // Roles, Users, Permissions
    public string? AppliesToIdsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime? ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}

/// <summary>
/// قاعدة بيانات الوحدات الأساسية للصلاحيات - extracted from ZIP ERD PermissionBase (lines 8680-8697).
/// </summary>
public class PermissionBaseModule : BaseAuditableEntity
{
    public string ModuleCode { get; set; } = string.Empty; // STD, EMP, FIN, AST
    public string ModuleNameAr { get; set; } = string.Empty;
    public string? ModuleNameEn { get; set; }
    public string? SectionCode { get; set; }
    public string? SectionNameAr { get; set; }
    public string? SectionNameEn { get; set; }
    public string? Description { get; set; }
    public string? DefaultPermissionsJson { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
}

/// <summary>
/// صلاحيات شؤون الطلاب الأساسية - extracted from ZIP ERD StudentBasePermissions.
/// Uses custom string permission keys rather than fragmented enums.
/// </summary>
public class StudentBasePermission : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty; // student.enroll, student.transfer, student.promote, student.withdraw
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; } // تسجيل، نقل، ترفيع، انسحاب، ملف شخصي
    public bool RequiresPrincipalApproval { get; set; }
    public bool RequiresGuardianConsent { get; set; }
    public bool IsSensitive { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

/// <summary>
/// صلاحيات الشؤون الأكاديمية والدرجات - extracted from ZIP ERD StudentAcademicPermissions.
/// </summary>
public class StudentAcademicPermission : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty; // grades.enter, grades.edit, grades.lock, attendance.record, attendance.excuse
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; } // رصد درجات، تعديل درجات، قفل درجات، حضور وغياب، أعذار
    public bool IsTimeBound { get; set; }
    public string? AllowedWindowDays { get; set; }
    public bool RequiresLockOverride { get; set; }
    public bool RequiresSupervisorApproval { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

/// <summary>
/// صلاحيات الشؤون المالية للطلاب - extracted from ZIP ERD StudentFinancePermissions.
/// Utilizes high-precision decimal limits safe for Oracle 19c.
/// </summary>
public class StudentFinancePermission : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty; // fee.exempt, fee.discount, invoice.cancel, payment.collect, payment.reverse
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; } // إعفاء، خصم، إلغاء فاتورة، تحصيل، استرجاع
    public decimal MaxAmountLimit { get; set; }
    public decimal MaxDiscountPercentage { get; set; }
    public bool RequiresDirectorApproval { get; set; }
    public bool RequiresBoardApproval { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

/// <summary>
/// صلاحيات مكاتب ومديريات التعليم - extracted from ZIP ERD OfficePermissions.
/// </summary>
public class OfficePermission : BaseAuditableEntity
{
    public long OfficeId { get; set; }
    public string PermissionKey { get; set; } = string.Empty; // office.supervise, office.audit, office.transfer_override, office.report_access
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? ScopeType { get; set; } // جميع المدارس، قطاع جغرافي، مرحلة دراسية
    public string? ScopeTargetJson { get; set; }
    public bool CanOverrideSchoolDecision { get; set; }
    public bool IsReadOnly { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

/// <summary>
/// مصفوفة صلاحيات السلوك الطلابي - extracted from ZIP ERD BehaviorPermissionMatrix.
/// </summary>
public class BehaviorPermissionMatrix : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public long RoleId { get; set; }
    public string BehaviorLevel { get; set; } = string.Empty; // الدرجة الأولى، الثانية، الثالثة، الرابعة، الخامسة
    public bool CanRecord { get; set; }
    public bool CanInvestigate { get; set; }
    public bool CanDecidePenalty { get; set; }
    public bool CanExecutePenalty { get; set; }
    public bool CanWaivePenalty { get; set; }
    public bool RequiresCommitteeDecision { get; set; }
    public string? Notes { get; set; }

    public virtual SystemRole? Role { get; set; }
}

/// <summary>
/// صلاحيات التوجيه والإرشاد والسلوك - extracted from ZIP ERD BehaviorPermissions.
/// </summary>
public class BehaviorPermission : BaseAuditableEntity
{
    public long SchoolId { get; set; }
    public string PermissionKey { get; set; } = string.Empty; // behavior.record, behavior.investigate, behavior.penalize, guidance.counseling
    public string PermissionNameAr { get; set; } = string.Empty;
    public string? PermissionNameEn { get; set; }
    public string? Category { get; set; } // رصد سلوك، تحقيق، عقوبة، توجيه وإرشاد، استدعاء ولي أمر
    public bool IsConfidential { get; set; }
    public bool RequiresSocialWorkerRole { get; set; }
    public string? AllowedRolesJson { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Notes { get; set; }
}

/// <summary>
/// سجل تدقيق شامل لجميع العمليات الحساسة - extracted from ZIP ERD AuditLog (lines 8859-8885).
/// Designed for immutable, read-only audit logging of system transactions.
/// </summary>
public class SystemAuditLog : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public long UserId { get; set; }
    public string? UserRoleAtExecution { get; set; }
    public string ActionType { get; set; } = string.Empty; // INSERT, UPDATE, DELETE, GRANT, REVOKE, APPROVE, REJECT, LOGIN, LOGOUT
    public string EntityType { get; set; } = string.Empty; // Student, Grade, Payment, User, Role, Permission
    public long? EntityId { get; set; }
    public string? OldValueJson { get; set; }
    public string? NewValueJson { get; set; }
    public string? ChangeSummary { get; set; }
    public string? TableName { get; set; }
    public string? FieldName { get; set; }
    public string? IpAddress { get; set; }
    public string? DeviceType { get; set; }
    public string? UserAgent { get; set; }
    public string? SessionId { get; set; }
    public string? AccessContextJson { get; set; }
    public string? Severity { get; set; } // Info, Warning, Critical
    public decimal RiskScore { get; set; }
    public bool IsSuspicious { get; set; }
    public bool WasAllowed { get; set; } = true;
    public string? RejectionReason { get; set; }
    public string? Notes { get; set; }
    public DateTime ActionTimestamp { get; set; } = DateTime.UtcNow;

    public virtual SystemUser? User { get; set; }
}

/// <summary>
/// سجل تدقيق صلاحيات الطالب - extracted from ZIP ERD StudentPermissionAudit (lines 8887-8903).
/// </summary>
public class StudentPermissionAuditLog : BaseAuditableEntity
{
    public long StudentId { get; set; }
    public long SchoolId { get; set; }
    public long UserId { get; set; }
    public string? UserRole { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string EntityType { get; set; } = string.Empty;
    public long? EntityId { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public string? AccessContextJson { get; set; }
    public bool WasAllowed { get; set; }
    public string? RejectionReason { get; set; }
    public decimal RiskScore { get; set; }
    public DateTime ActionTimestamp { get; set; } = DateTime.UtcNow;
}

/// <summary>
/// مصفوفة الأدوار المرجعية - extracted from ZIP ERD RoleMatrix (lines 8905-8922).
/// </summary>
public class RoleMatrix : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public string RoleCode { get; set; } = string.Empty;
    public string RoleNameAr { get; set; } = string.Empty;
    public string? RoleNameEn { get; set; }
    public int RoleType { get; set; } // 1=System, 2=School, 3=Office
    public string? PermissionsJson { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;
    public int SortOrder { get; set; }
}

/// <summary>
/// قواعد الامتيازات والتدقيق التلقائي - extracted from ZIP ERD PrivilegeRules (lines 8924-8943).
/// </summary>
public class PrivilegeRule : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public string RuleCode { get; set; } = string.Empty;
    public string RuleNameAr { get; set; } = string.Empty;
    public string? RuleNameEn { get; set; }
    public string? RuleCategory { get; set; } // Audit, Approvals, Limits, Alerts
    public string? AppliesToType { get; set; }
    public string? ConditionJson { get; set; }
    public string? TriggerAction { get; set; } // LogToAudit, RequestApproval, SendAlert, BlockOperation
    public string? ActionParametersJson { get; set; }
    public int Priority { get; set; } = 50;
    public bool IsActive { get; set; } = true;
}

/// <summary>
/// سجل مصفوفة وصلاحيات السلوك (Backward compatibility alias / helper).
/// </summary>
public class BehaviorPermissionRecord : BaseAuditableEntity
{
    public long? SchoolId { get; set; }
    public long? RoleId { get; set; }
    public string Category { get; set; } = string.Empty; // Behavioral, Complaint, Guidance, Monitoring
    public string? SubCategory { get; set; }
    public string PermissionKey { get; set; } = string.Empty;
    public string? AllowedActionsJson { get; set; }
    public string? Scope { get; set; }
    public bool IsSensitive { get; set; }
    public bool RequiresJustification { get; set; }
    public bool JustificationApprovalRequired { get; set; }
    public string? DescriptionAr { get; set; }
    public bool IsActive { get; set; } = true;

    public virtual SystemRole? Role { get; set; }
}
