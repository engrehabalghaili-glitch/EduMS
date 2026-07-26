using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M8_AuthenticationUsers.Configurations;

public class UserActivityLogConfiguration : IEntityTypeConfiguration<UserActivityLog>
{
    public void Configure(EntityTypeBuilder<UserActivityLog> builder)
    {
        builder.ToTable("USER_ACTIVITY_LOG");

        builder.Property(e => e.ActivityType)
            .HasColumnName("ACTIVITY_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.ActivityTimestamp)
            .HasColumnName("ACTIVITY_TIMESTAMP");

        builder.Property(e => e.ActivityStatus)
            .HasColumnName("ACTIVITY_STATUS");

        builder.Property(e => e.FailureReason)
            .HasColumnName("FAILURE_REASON")
            .HasMaxLength(250);

        builder.Property(e => e.IpAddress)
            .HasColumnName("IP_ADDRESS")
            .HasMaxLength(50);

        builder.Property(e => e.DeviceType)
            .HasColumnName("DEVICE_TYPE")
            .HasMaxLength(50);

        builder.Property(e => e.DeviceName)
            .HasColumnName("DEVICE_NAME")
            .HasMaxLength(150);

        builder.Property(e => e.OperatingSystem)
            .HasColumnName("OPERATING_SYSTEM")
            .HasMaxLength(100);

        builder.Property(e => e.Browser)
            .HasColumnName("BROWSER")
            .HasMaxLength(100);

        builder.Property(e => e.UserAgent)
            .HasColumnName("USER_AGENT")
            .HasMaxLength(500);

        builder.Property(e => e.LocationText)
            .HasColumnName("LOCATION_TEXT")
            .HasMaxLength(250);

        builder.Property(e => e.SessionId)
            .HasColumnName("SESSION_ID")
            .HasMaxLength(100);

        builder.Property(e => e.ActionDetailsJson)
            .HasColumnName("ACTION_DETAILS_JSON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.UserId, e.ActivityTimestamp });
    }
}

public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> builder)
    {
        builder.ToTable("PERMISSION_TYPE");

        builder.Property(e => e.TypeCode)
            .HasColumnName("TYPE_CODE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.TypeNameAr)
            .HasColumnName("TYPE_NAME_AR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.TypeNameEn)
            .HasColumnName("TYPE_NAME_EN")
            .HasMaxLength(150);

        builder.Property(e => e.Category)
            .HasColumnName("CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.ScopeType)
            .HasColumnName("SCOPE_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.RiskLevel)
            .HasColumnName("RISK_LEVEL")
            .HasMaxLength(50);

        builder.Property(e => e.RequiresApproval)
            .HasColumnName("REQUIRES_APPROVAL");

        builder.Property(e => e.ApprovalLevel)
            .HasColumnName("APPROVAL_LEVEL")
            .HasMaxLength(100);

        builder.Property(e => e.DescriptionAr)
            .HasColumnName("DESCRIPTION_AR");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.IsSystem)
            .HasColumnName("IS_SYSTEM");

        builder.Property(e => e.SortOrder)
            .HasColumnName("SORT_ORDER");

        builder.HasIndex(e => e.TypeCode).IsUnique();
    }
}

public class SystemPermissionConfiguration : IEntityTypeConfiguration<SystemPermission>
{
    public void Configure(EntityTypeBuilder<SystemPermission> builder)
    {
        builder.ToTable("SYSTEM_PERMISSION");

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.Module)
            .HasColumnName("MODULE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.SubModule)
            .HasColumnName("SUB_MODULE")
            .HasMaxLength(100);

        builder.Property(e => e.ActionType)
            .HasColumnName("ACTION_TYPE")
            .HasMaxLength(50);

        builder.Property(e => e.PermissionTypeId)
            .HasColumnName("PERMISSION_TYPE_ID");

        builder.Property(e => e.DefaultScope)
            .HasColumnName("DEFAULT_SCOPE")
            .HasMaxLength(100);

        builder.Property(e => e.NameAr)
            .HasColumnName("NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.NameEn)
            .HasColumnName("NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.DescriptionAr)
            .HasColumnName("DESCRIPTION_AR");

        builder.Property(e => e.RiskLevel)
            .HasColumnName("RISK_LEVEL")
            .HasMaxLength(50);

        builder.Property(e => e.IsSensitive)
            .HasColumnName("IS_SENSITIVE");

        builder.Property(e => e.RequiresLogging)
            .HasColumnName("REQUIRES_LOGGING");

        builder.Property(e => e.ConditionsJson)
            .HasColumnName("CONDITIONS_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.HasOne(e => e.PermissionType)
            .WithMany()
            .HasForeignKey(e => e.PermissionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.PermissionKey).IsUnique();
    }
}

public class SystemRoleConfiguration : IEntityTypeConfiguration<SystemRole>
{
    public void Configure(EntityTypeBuilder<SystemRole> builder)
    {
        builder.ToTable("SYSTEM_ROLE");

        builder.Property(e => e.RoleCode)
            .HasColumnName("ROLE_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.RoleNameAr)
            .HasColumnName("ROLE_NAME_AR")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.RoleNameEn)
            .HasColumnName("ROLE_NAME_EN")
            .HasMaxLength(200);

        builder.Property(e => e.RoleType)
            .HasColumnName("ROLE_TYPE");

        builder.Property(e => e.HierarchyLevel)
            .HasColumnName("HIERARCHY_LEVEL");

        builder.Property(e => e.ParentRoleId)
            .HasColumnName("PARENT_ROLE_ID");

        builder.Property(e => e.IsInheritable)
            .HasColumnName("IS_INHERITABLE");

        builder.Property(e => e.IsAssignable)
            .HasColumnName("IS_ASSIGNABLE");

        builder.Property(e => e.IsSystem)
            .HasColumnName("IS_SYSTEM");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.DescriptionAr)
            .HasColumnName("DESCRIPTION_AR");

        builder.HasOne(e => e.ParentRole)
            .WithMany()
            .HasForeignKey(e => e.ParentRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.RoleCode).IsUnique();
    }
}

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("ROLE_PERMISSION");

        builder.Property(e => e.ScopeOverride)
            .HasColumnName("SCOPE_OVERRIDE")
            .HasMaxLength(100);

        builder.Property(e => e.IsInherited)
            .HasColumnName("IS_INHERITED");

        builder.Property(e => e.InheritedFromRoleId)
            .HasColumnName("INHERITED_FROM_ROLE_ID");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.StartDate)
            .HasColumnName("START_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.GrantedByUserId)
            .HasColumnName("GRANTED_BY_USER_ID");

        builder.Property(e => e.GrantedAt)
            .HasColumnName("GRANTED_AT");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Permission)
            .WithMany()
            .HasForeignKey(e => e.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.RoleId, e.PermissionId });
    }
}

public class UserRoleAssignmentConfiguration : IEntityTypeConfiguration<UserRoleAssignment>
{
    public void Configure(EntityTypeBuilder<UserRoleAssignment> builder)
    {
        builder.ToTable("USER_ROLE_ASSIGNMENT");

        builder.Property(e => e.IsPrimary)
            .HasColumnName("IS_PRIMARY");

        builder.Property(e => e.ScopeContextJson)
            .HasColumnName("SCOPE_CONTEXT_JSON");

        builder.Property(e => e.StartDate)
            .HasColumnName("START_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.AssignedByUserId)
            .HasColumnName("ASSIGNED_BY_USER_ID");

        builder.Property(e => e.AssignedAt)
            .HasColumnName("ASSIGNED_AT");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.UserId, e.RoleId });
    }
}

public class GovernanceRbacRuleConfiguration : IEntityTypeConfiguration<GovernanceRbacRule>
{
    public void Configure(EntityTypeBuilder<GovernanceRbacRule> builder)
    {
        builder.ToTable("GOVERNANCE_RBAC_RULE");

        builder.Property(e => e.AllowedAction)
            .HasColumnName("ALLOWED_ACTION")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.CanDelegate)
            .HasColumnName("CAN_DELEGATE");

        builder.Property(e => e.ApprovalRequired)
            .HasColumnName("APPROVAL_REQUIRED");

        builder.Property(e => e.ApprovalRoleId)
            .HasColumnName("APPROVAL_ROLE_ID");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class UserDirectPermissionConfiguration : IEntityTypeConfiguration<UserDirectPermission>
{
    public void Configure(EntityTypeBuilder<UserDirectPermission> builder)
    {
        builder.ToTable("USER_DIRECT_PERMISSION");

        builder.Property(e => e.ScopeOverride)
            .HasColumnName("SCOPE_OVERRIDE")
            .HasMaxLength(100);

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.StartDate)
            .HasColumnName("START_DATE");

        builder.Property(e => e.EndDate)
            .HasColumnName("END_DATE");

        builder.Property(e => e.GrantedByUserId)
            .HasColumnName("GRANTED_BY_USER_ID");

        builder.Property(e => e.GrantedAt)
            .HasColumnName("GRANTED_AT");

        builder.Property(e => e.Reason)
            .HasColumnName("REASON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Permission)
            .WithMany()
            .HasForeignKey(e => e.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class AccessPolicyConfiguration : IEntityTypeConfiguration<AccessPolicy>
{
    public void Configure(EntityTypeBuilder<AccessPolicy> builder)
    {
        builder.ToTable("ACCESS_POLICY");

        builder.Property(e => e.PolicyCode)
            .HasColumnName("POLICY_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.PolicyNameAr)
            .HasColumnName("POLICY_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PolicyNameEn)
            .HasColumnName("POLICY_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.PolicyType)
            .HasColumnName("POLICY_TYPE");

        builder.Property(e => e.PolicyRuleJson)
            .HasColumnName("POLICY_RULE_JSON");

        builder.Property(e => e.PolicyEffect)
            .HasColumnName("POLICY_EFFECT");

        builder.Property(e => e.Priority)
            .HasColumnName("PRIORITY");

        builder.Property(e => e.AppliesToType)
            .HasColumnName("APPLIES_TO_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.AppliesToIdsJson)
            .HasColumnName("APPLIES_TO_IDS_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.ValidFrom)
            .HasColumnName("VALID_FROM");

        builder.Property(e => e.ValidTo)
            .HasColumnName("VALID_TO");
    }
}

public class PermissionBaseModuleConfiguration : IEntityTypeConfiguration<PermissionBaseModule>
{
    public void Configure(EntityTypeBuilder<PermissionBaseModule> builder)
    {
        builder.ToTable("PERMISSION_BASE_MODULE");

        builder.Property(e => e.ModuleCode)
            .HasColumnName("MODULE_CODE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.ModuleNameAr)
            .HasColumnName("MODULE_NAME_AR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.ModuleNameEn)
            .HasColumnName("MODULE_NAME_EN")
            .HasMaxLength(150);

        builder.Property(e => e.SectionCode)
            .HasColumnName("SECTION_CODE")
            .HasMaxLength(50);

        builder.Property(e => e.SectionNameAr)
            .HasColumnName("SECTION_NAME_AR")
            .HasMaxLength(150);

        builder.Property(e => e.SectionNameEn)
            .HasColumnName("SECTION_NAME_EN")
            .HasMaxLength(150);

        builder.Property(e => e.Description)
            .HasColumnName("DESCRIPTION");

        builder.Property(e => e.DefaultPermissionsJson)
            .HasColumnName("DEFAULT_PERMISSIONS_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.SortOrder)
            .HasColumnName("SORT_ORDER");
    }
}

public class StudentBasePermissionConfiguration : IEntityTypeConfiguration<StudentBasePermission>
{
    public void Configure(EntityTypeBuilder<StudentBasePermission> builder)
    {
        builder.ToTable("STUDENT_BASE_PERMISSION");

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.PermissionNameAr)
            .HasColumnName("PERMISSION_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PermissionNameEn)
            .HasColumnName("PERMISSION_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.Category)
            .HasColumnName("CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.RequiresPrincipalApproval)
            .HasColumnName("REQUIRES_PRINCIPAL_APPROVAL");

        builder.Property(e => e.RequiresGuardianConsent)
            .HasColumnName("REQUIRES_GUARDIAN_CONSENT");

        builder.Property(e => e.IsSensitive)
            .HasColumnName("IS_SENSITIVE");

        builder.Property(e => e.AllowedRolesJson)
            .HasColumnName("ALLOWED_ROLES_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");
    }
}

public class StudentAcademicPermissionConfiguration : IEntityTypeConfiguration<StudentAcademicPermission>
{
    public void Configure(EntityTypeBuilder<StudentAcademicPermission> builder)
    {
        builder.ToTable("STUDENT_ACADEMIC_PERMISSION");

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.PermissionNameAr)
            .HasColumnName("PERMISSION_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PermissionNameEn)
            .HasColumnName("PERMISSION_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.Category)
            .HasColumnName("CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.IsTimeBound)
            .HasColumnName("IS_TIME_BOUND");

        builder.Property(e => e.AllowedWindowDays)
            .HasColumnName("ALLOWED_WINDOW_DAYS")
            .HasMaxLength(50);

        builder.Property(e => e.RequiresLockOverride)
            .HasColumnName("REQUIRES_LOCK_OVERRIDE");

        builder.Property(e => e.RequiresSupervisorApproval)
            .HasColumnName("REQUIRES_SUPERVISOR_APPROVAL");

        builder.Property(e => e.AllowedRolesJson)
            .HasColumnName("ALLOWED_ROLES_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");
    }
}

public class StudentFinancePermissionConfiguration : IEntityTypeConfiguration<StudentFinancePermission>
{
    public void Configure(EntityTypeBuilder<StudentFinancePermission> builder)
    {
        builder.ToTable("STUDENT_FINANCE_PERMISSION");

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.PermissionNameAr)
            .HasColumnName("PERMISSION_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PermissionNameEn)
            .HasColumnName("PERMISSION_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.Category)
            .HasColumnName("CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.MaxAmountLimit)
            .HasColumnName("MAX_AMOUNT_LIMIT")
            .HasPrecision(19, 4);

        builder.Property(e => e.MaxDiscountPercentage)
            .HasColumnName("MAX_DISCOUNT_PCT")
            .HasPrecision(19, 4);

        builder.Property(e => e.RequiresDirectorApproval)
            .HasColumnName("REQUIRES_DIRECTOR_APPROVAL");

        builder.Property(e => e.RequiresBoardApproval)
            .HasColumnName("REQUIRES_BOARD_APPROVAL");

        builder.Property(e => e.AllowedRolesJson)
            .HasColumnName("ALLOWED_ROLES_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");
    }
}

public class OfficePermissionConfiguration : IEntityTypeConfiguration<OfficePermission>
{
    public void Configure(EntityTypeBuilder<OfficePermission> builder)
    {
        builder.ToTable("OFFICE_PERMISSION");

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.PermissionNameAr)
            .HasColumnName("PERMISSION_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PermissionNameEn)
            .HasColumnName("PERMISSION_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.ScopeType)
            .HasColumnName("SCOPE_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.ScopeTargetJson)
            .HasColumnName("SCOPE_TARGET_JSON");

        builder.Property(e => e.CanOverrideSchoolDecision)
            .HasColumnName("CAN_OVERRIDE_SCHOOL_DECISION");

        builder.Property(e => e.IsReadOnly)
            .HasColumnName("IS_READ_ONLY");

        builder.Property(e => e.AllowedRolesJson)
            .HasColumnName("ALLOWED_ROLES_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");
    }
}

public class BehaviorPermissionMatrixConfiguration : IEntityTypeConfiguration<BehaviorPermissionMatrix>
{
    public void Configure(EntityTypeBuilder<BehaviorPermissionMatrix> builder)
    {
        builder.ToTable("BEHAVIOR_PERMISSION_MATRIX");

        builder.Property(e => e.BehaviorLevel)
            .HasColumnName("BEHAVIOR_LEVEL")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.CanRecord)
            .HasColumnName("CAN_RECORD");

        builder.Property(e => e.CanInvestigate)
            .HasColumnName("CAN_INVESTIGATE");

        builder.Property(e => e.CanDecidePenalty)
            .HasColumnName("CAN_DECIDE_PENALTY");

        builder.Property(e => e.CanExecutePenalty)
            .HasColumnName("CAN_EXECUTE_PENALTY");

        builder.Property(e => e.CanWaivePenalty)
            .HasColumnName("CAN_WAIVE_PENALTY");

        builder.Property(e => e.RequiresCommitteeDecision)
            .HasColumnName("REQUIRES_COMMITTEE_DECISION");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public class BehaviorPermissionConfiguration : IEntityTypeConfiguration<BehaviorPermission>
{
    public void Configure(EntityTypeBuilder<BehaviorPermission> builder)
    {
        builder.ToTable("BEHAVIOR_PERMISSION");

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.PermissionNameAr)
            .HasColumnName("PERMISSION_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.PermissionNameEn)
            .HasColumnName("PERMISSION_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.Category)
            .HasColumnName("CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.IsConfidential)
            .HasColumnName("IS_CONFIDENTIAL");

        builder.Property(e => e.RequiresSocialWorkerRole)
            .HasColumnName("REQUIRES_SOCIAL_WORKER_ROLE");

        builder.Property(e => e.AllowedRolesJson)
            .HasColumnName("ALLOWED_ROLES_JSON");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");
    }
}

public class SystemAuditLogConfiguration : IEntityTypeConfiguration<SystemAuditLog>
{
    public void Configure(EntityTypeBuilder<SystemAuditLog> builder)
    {
        builder.ToTable("SYSTEM_AUDIT_LOG");

        builder.Property(e => e.UserRoleAtExecution)
            .HasColumnName("USER_ROLE_AT_EXEC")
            .HasMaxLength(100);

        builder.Property(e => e.ActionType)
            .HasColumnName("ACTION_TYPE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.EntityType)
            .HasColumnName("ENTITY_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.EntityId)
            .HasColumnName("ENTITY_ID");

        builder.Property(e => e.OldValueJson)
            .HasColumnName("OLD_VALUE_JSON");

        builder.Property(e => e.NewValueJson)
            .HasColumnName("NEW_VALUE_JSON");

        builder.Property(e => e.ChangeSummary)
            .HasColumnName("CHANGE_SUMMARY");

        builder.Property(e => e.TableName)
            .HasColumnName("TABLE_NAME")
            .HasMaxLength(100);

        builder.Property(e => e.FieldName)
            .HasColumnName("FIELD_NAME")
            .HasMaxLength(100);

        builder.Property(e => e.IpAddress)
            .HasColumnName("IP_ADDRESS")
            .HasMaxLength(50);

        builder.Property(e => e.DeviceType)
            .HasColumnName("DEVICE_TYPE")
            .HasMaxLength(50);

        builder.Property(e => e.UserAgent)
            .HasColumnName("USER_AGENT")
            .HasMaxLength(500);

        builder.Property(e => e.SessionId)
            .HasColumnName("SESSION_ID")
            .HasMaxLength(100);

        builder.Property(e => e.AccessContextJson)
            .HasColumnName("ACCESS_CONTEXT_JSON");

        builder.Property(e => e.Severity)
            .HasColumnName("SEVERITY")
            .HasMaxLength(50);

        builder.Property(e => e.RiskScore)
            .HasColumnName("RISK_SCORE")
            .HasPrecision(19, 4);

        builder.Property(e => e.IsSuspicious)
            .HasColumnName("IS_SUSPICIOUS");

        builder.Property(e => e.WasAllowed)
            .HasColumnName("WAS_ALLOWED");

        builder.Property(e => e.RejectionReason)
            .HasColumnName("REJECTION_REASON");

        builder.Property(e => e.Notes)
            .HasColumnName("NOTES");

        builder.Property(e => e.ActionTimestamp)
            .HasColumnName("ACTION_TIMESTAMP");

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => new { e.UserId, e.ActionTimestamp });
    }
}

public class StudentPermissionAuditLogConfiguration : IEntityTypeConfiguration<StudentPermissionAuditLog>
{
    public void Configure(EntityTypeBuilder<StudentPermissionAuditLog> builder)
    {
        builder.ToTable("STUDENT_PERM_AUDIT_LOG");

        builder.Property(e => e.UserRole)
            .HasColumnName("USER_ROLE")
            .HasMaxLength(100);

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.EntityType)
            .HasColumnName("ENTITY_TYPE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.EntityId)
            .HasColumnName("ENTITY_ID");

        builder.Property(e => e.ActionType)
            .HasColumnName("ACTION_TYPE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.AccessContextJson)
            .HasColumnName("ACCESS_CONTEXT_JSON");

        builder.Property(e => e.WasAllowed)
            .HasColumnName("WAS_ALLOWED");

        builder.Property(e => e.RejectionReason)
            .HasColumnName("REJECTION_REASON");

        builder.Property(e => e.RiskScore)
            .HasColumnName("RISK_SCORE")
            .HasPrecision(19, 4);

        builder.Property(e => e.ActionTimestamp)
            .HasColumnName("ACTION_TIMESTAMP");
    }
}

public class RoleMatrixConfiguration : IEntityTypeConfiguration<RoleMatrix>
{
    public void Configure(EntityTypeBuilder<RoleMatrix> builder)
    {
        builder.ToTable("ROLE_MATRIX");

        builder.Property(e => e.RoleCode)
            .HasColumnName("ROLE_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.RoleNameAr)
            .HasColumnName("ROLE_NAME_AR")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.RoleNameEn)
            .HasColumnName("ROLE_NAME_EN")
            .HasMaxLength(200);

        builder.Property(e => e.RoleType)
            .HasColumnName("ROLE_TYPE");

        builder.Property(e => e.PermissionsJson)
            .HasColumnName("PERMISSIONS_JSON");

        builder.Property(e => e.DescriptionAr)
            .HasColumnName("DESCRIPTION_AR");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.Property(e => e.SortOrder)
            .HasColumnName("SORT_ORDER");

        builder.HasIndex(e => e.RoleCode).IsUnique();
    }
}

public class PrivilegeRuleConfiguration : IEntityTypeConfiguration<PrivilegeRule>
{
    public void Configure(EntityTypeBuilder<PrivilegeRule> builder)
    {
        builder.ToTable("PRIVILEGE_RULE");

        builder.Property(e => e.RuleCode)
            .HasColumnName("RULE_CODE")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.RuleNameAr)
            .HasColumnName("RULE_NAME_AR")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(e => e.RuleNameEn)
            .HasColumnName("RULE_NAME_EN")
            .HasMaxLength(250);

        builder.Property(e => e.RuleCategory)
            .HasColumnName("RULE_CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.AppliesToType)
            .HasColumnName("APPLIES_TO_TYPE")
            .HasMaxLength(100);

        builder.Property(e => e.ConditionJson)
            .HasColumnName("CONDITION_JSON");

        builder.Property(e => e.TriggerAction)
            .HasColumnName("TRIGGER_ACTION")
            .HasMaxLength(100);

        builder.Property(e => e.ActionParametersJson)
            .HasColumnName("ACTION_PARAMETERS_JSON");

        builder.Property(e => e.Priority)
            .HasColumnName("PRIORITY");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");
    }
}

public class BehaviorPermissionRecordConfiguration : IEntityTypeConfiguration<BehaviorPermissionRecord>
{
    public void Configure(EntityTypeBuilder<BehaviorPermissionRecord> builder)
    {
        builder.ToTable("BEHAVIOR_PERMISSION_RECORD");

        builder.Property(e => e.Category)
            .HasColumnName("CATEGORY")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(e => e.SubCategory)
            .HasColumnName("SUB_CATEGORY")
            .HasMaxLength(100);

        builder.Property(e => e.PermissionKey)
            .HasColumnName("PERMISSION_KEY")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.AllowedActionsJson)
            .HasColumnName("ALLOWED_ACTIONS_JSON");

        builder.Property(e => e.Scope)
            .HasColumnName("SCOPE")
            .HasMaxLength(100);

        builder.Property(e => e.IsSensitive)
            .HasColumnName("IS_SENSITIVE");

        builder.Property(e => e.RequiresJustification)
            .HasColumnName("REQUIRES_JUSTIFICATION");

        builder.Property(e => e.JustificationApprovalRequired)
            .HasColumnName("JUSTIFICATION_APPROVAL_REQ");

        builder.Property(e => e.DescriptionAr)
            .HasColumnName("DESCRIPTION_AR");

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE");

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
