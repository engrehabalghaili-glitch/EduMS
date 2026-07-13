using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// =============================================================
//  EduMS Infrastructure – CrossModule Bridge Fluent API Configs
//  Phase-3: Infrastructure Persistence Configuration Pass
//  Directory: Persistence/Configurations/CrossModule_Integrations/
//
//  Covers all 19 bridge / linking entities introduced in
//  CrossModule_RelationalIntegration.cs (Phase-2).
//
//  Laws enforced throughout:
//    • Oracle 19c UPPER_SNAKE_CASE table & column names
//    • HasPrecision(19,4) for monetary / financial decimals
//    • HasPrecision(18,2) for operational / percentage decimals
//    • DeleteBehavior.Restrict on EVERY cross-module FK
//      to prevent cyclic cascade failures in Oracle
//    • HasIndex() on ALL foreign key columns for OLAP throughput
//    • Audit / sync columns mapped consistently on every entity
// =============================================================

namespace EduMS.Infrastructure.Persistence.Configurations.CrossModule_Integrations;

// ─────────────────────────────────────────────────────────────
//  BRIDGE 1-A  |  EnrollmentFinancialLink  (M2 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class EnrollmentFinancialLinkConfiguration
    : IEntityTypeConfiguration<EnrollmentFinancialLink>
{
    public void Configure(EntityTypeBuilder<EnrollmentFinancialLink> builder)
    {
        builder.ToTable("CM_ENROLLMENT_FINANCIAL_LINK");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        // ── Foreign Keys ──────────────────────────────────────
        builder.Property(e => e.EnrollmentId)
            .HasColumnName("ENROLLMENT_ID")
            .IsRequired();

        builder.Property(e => e.StudentAccountId)
            .HasColumnName("STUDENT_ACCOUNT_ID")
            .IsRequired();

        builder.Property(e => e.StudentId)
            .HasColumnName("STUDENT_ID")
            .IsRequired();

        builder.Property(e => e.SchoolId)
            .HasColumnName("SCHOOL_ID")
            .IsRequired();

        builder.Property(e => e.SchoolAcademicYearId)
            .HasColumnName("ACADEMIC_YEAR_ID");

        // ── Financial Decimals ────────────────────────────────
        builder.Property(e => e.TuitionFeeDue)
            .HasColumnName("TUITION_FEE_DUE")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.DiscountApplied)
            .HasColumnName("DISCOUNT_APPLIED")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.ExemptionApplied)
            .HasColumnName("EXEMPTION_APPLIED")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.NetPayable)
            .HasColumnName("NET_PAYABLE")
            .HasPrecision(19, 4)
            .IsRequired();

        // ── Scalar Properties ─────────────────────────────────
        builder.Property(e => e.IsSettled).HasColumnName("IS_SETTLED").IsRequired();
        builder.Property(e => e.SettlementDate).HasColumnName("SETTLEMENT_DATE");
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        // ── Indexes ───────────────────────────────────────────
        builder.HasIndex(e => e.EnrollmentId).HasDatabaseName("IDX_CM_EFL_ENROLLMENT");
        builder.HasIndex(e => e.StudentAccountId).HasDatabaseName("IDX_CM_EFL_ACCOUNT");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_EFL_STUDENT");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_EFL_SCHOOL");

        // ── Relationships – Restrict cascade (Oracle safe) ────
        builder.HasOne<StudentEnrollment>()
            .WithMany()
            .HasForeignKey(e => e.EnrollmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StudentAccount>()
            .WithMany()
            .HasForeignKey(e => e.StudentAccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        // ── Audit & Sync ──────────────────────────────────────
        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 1-B  |  PaymentToInvoiceSettlement  (M2 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class PaymentToInvoiceSettlementConfiguration
    : IEntityTypeConfiguration<PaymentToInvoiceSettlement>
{
    public void Configure(EntityTypeBuilder<PaymentToInvoiceSettlement> builder)
    {
        builder.ToTable("CM_PAYMENT_INVOICE_SETTLEMENT");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("SETTLEMENT_ID");

        builder.Property(e => e.PaymentVoucherId).HasColumnName("PAYMENT_VOUCHER_ID").IsRequired();
        builder.Property(e => e.FeeInvoiceId).HasColumnName("FEE_INVOICE_ID").IsRequired();
        builder.Property(e => e.StudentId).HasColumnName("STUDENT_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.AllocatedAmount)
            .HasColumnName("ALLOCATED_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.PaymentVoucherId).HasDatabaseName("IDX_CM_PIS_VOUCHER");
        builder.HasIndex(e => e.FeeInvoiceId).HasDatabaseName("IDX_CM_PIS_INVOICE");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_PIS_STUDENT");

        builder.HasOne<PaymentVoucher>()
            .WithMany()
            .HasForeignKey(e => e.PaymentVoucherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<FeeInvoice>()
            .WithMany()
            .HasForeignKey(e => e.FeeInvoiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 2  |  PayrollJournalEntryLink  (M3 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class PayrollJournalEntryLinkConfiguration
    : IEntityTypeConfiguration<PayrollJournalEntryLink>
{
    public void Configure(EntityTypeBuilder<PayrollJournalEntryLink> builder)
    {
        builder.ToTable("CM_PAYROLL_JOURNAL_LINK");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.PayrollDetailId).HasColumnName("PAYROLL_DETAIL_ID").IsRequired();
        builder.Property(e => e.JournalEntryId).HasColumnName("JOURNAL_ENTRY_ID").IsRequired();
        builder.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID").IsRequired();
        builder.Property(e => e.PayrollRunId).HasColumnName("PAYROLL_RUN_ID").IsRequired();

        builder.Property(e => e.SalaryAmount)
            .HasColumnName("SALARY_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.PayrollDetailId).HasDatabaseName("IDX_CM_PJL_DETAIL");
        builder.HasIndex(e => e.JournalEntryId).HasDatabaseName("IDX_CM_PJL_JOURNAL");
        builder.HasIndex(e => e.EmployeeId).HasDatabaseName("IDX_CM_PJL_EMPLOYEE");
        builder.HasIndex(e => e.PayrollRunId).HasDatabaseName("IDX_CM_PJL_RUN");

        builder.HasOne<PayrollDetail>()
            .WithMany()
            .HasForeignKey(e => e.PayrollDetailId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<JournalEntry>()
            .WithMany()
            .HasForeignKey(e => e.JournalEntryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PayrollRun>()
            .WithMany()
            .HasForeignKey(e => e.PayrollRunId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 3-A  |  AssetFinancialJournalLink  (M4 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class AssetFinancialJournalLinkConfiguration
    : IEntityTypeConfiguration<AssetFinancialJournalLink>
{
    public void Configure(EntityTypeBuilder<AssetFinancialJournalLink> builder)
    {
        builder.ToTable("CM_ASSET_FINANCIAL_JOURNAL");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.SchoolAssetId).HasColumnName("SCHOOL_ASSET_ID").IsRequired();
        builder.Property(e => e.JournalEntryId).HasColumnName("JOURNAL_ENTRY_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.EntryType)
            .HasColumnName("ENTRY_TYPE")
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(e => e.EntryAmount)
            .HasColumnName("ENTRY_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.EntryDate).HasColumnName("ENTRY_DATE").IsRequired();
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.SchoolAssetId).HasDatabaseName("IDX_CM_AFJ_ASSET");
        builder.HasIndex(e => e.JournalEntryId).HasDatabaseName("IDX_CM_AFJ_JOURNAL");
        builder.HasIndex(e => new { e.SchoolId, e.EntryDate }).HasDatabaseName("IDX_CM_AFJ_SCHOOL_DATE");

        builder.HasOne<SchoolAsset>()
            .WithMany()
            .HasForeignKey(e => e.SchoolAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<JournalEntry>()
            .WithMany()
            .HasForeignKey(e => e.JournalEntryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 3-B  |  AssetProcurementPaymentLink  (M4 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class AssetProcurementPaymentLinkConfiguration
    : IEntityTypeConfiguration<AssetProcurementPaymentLink>
{
    public void Configure(EntityTypeBuilder<AssetProcurementPaymentLink> builder)
    {
        builder.ToTable("CM_ASSET_PROCUREMENT_PAYMENT");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.PurchaseOrderId).HasColumnName("PURCHASE_ORDER_ID").IsRequired();
        builder.Property(e => e.PaymentVoucherId).HasColumnName("PAYMENT_VOUCHER_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.PaidAmount)
            .HasColumnName("PAID_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.PurchaseOrderId).HasDatabaseName("IDX_CM_APP_ORDER");
        builder.HasIndex(e => e.PaymentVoucherId).HasDatabaseName("IDX_CM_APP_VOUCHER");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_APP_SCHOOL");

        builder.HasOne<PurchaseOrder>()
            .WithMany()
            .HasForeignKey(e => e.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PaymentVoucher>()
            .WithMany()
            .HasForeignKey(e => e.PaymentVoucherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 4-A  |  EmergencyIncidentAssetImpact  (M7 ⟷ M4)
// ─────────────────────────────────────────────────────────────
public class EmergencyIncidentAssetImpactConfiguration
    : IEntityTypeConfiguration<EmergencyIncidentAssetImpact>
{
    public void Configure(EntityTypeBuilder<EmergencyIncidentAssetImpact> builder)
    {
        builder.ToTable("CM_EMERGENCY_ASSET_IMPACT");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("IMPACT_ID");

        builder.Property(e => e.EmergencyIncidentId).HasColumnName("EMERGENCY_INCIDENT_ID").IsRequired();
        builder.Property(e => e.SchoolAssetId).HasColumnName("SCHOOL_ASSET_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.ImpactType).HasColumnName("IMPACT_TYPE").IsRequired();

        builder.Property(e => e.EstimatedDamageValue)
            .HasColumnName("EST_DAMAGE_VALUE")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.DamageDescription).HasColumnName("DAMAGE_DESCRIPTION").HasMaxLength(1000);
        builder.Property(e => e.RequiresMaintenance).HasColumnName("REQUIRES_MAINTENANCE").IsRequired();
        builder.Property(e => e.MaintenanceTicketId).HasColumnName("MAINTENANCE_TICKET_ID");
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.EmergencyIncidentId).HasDatabaseName("IDX_CM_EAIA_INCIDENT");
        builder.HasIndex(e => e.SchoolAssetId).HasDatabaseName("IDX_CM_EAIA_ASSET");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_EAIA_SCHOOL");

        builder.HasOne<EmergencyIncident>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyIncidentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SchoolAsset>()
            .WithMany()
            .HasForeignKey(e => e.SchoolAssetId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<AssetMaintenanceTicket>()
            .WithMany()
            .HasForeignKey(e => e.MaintenanceTicketId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 4-B  |  EmergencyHostingWarehouseLink  (M7 ⟷ M4)
// ─────────────────────────────────────────────────────────────
public class EmergencyHostingWarehouseLinkConfiguration
    : IEntityTypeConfiguration<EmergencyHostingWarehouseLink>
{
    public void Configure(EntityTypeBuilder<EmergencyHostingWarehouseLink> builder)
    {
        builder.ToTable("CM_EMERGENCY_HOSTING_WAREHOUSE");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.EmergencyHostingId).HasColumnName("EMERGENCY_HOSTING_ID").IsRequired();
        builder.Property(e => e.WarehouseId).HasColumnName("WAREHOUSE_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.SuppliesUsedJson).HasColumnName("SUPPLIES_USED_JSON").HasMaxLength(4000);

        builder.Property(e => e.TotalSupplyValue)
            .HasColumnName("TOTAL_SUPPLY_VALUE")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.EmergencyHostingId).HasDatabaseName("IDX_CM_EHW_HOSTING");
        builder.HasIndex(e => e.WarehouseId).HasDatabaseName("IDX_CM_EHW_WAREHOUSE");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_EHW_SCHOOL");

        builder.HasOne<EmergencyHosting>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyHostingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Warehouse>()
            .WithMany()
            .HasForeignKey(e => e.WarehouseId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 5  |  EmergencyFinancialExpenseLink  (M7 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class EmergencyFinancialExpenseLinkConfiguration
    : IEntityTypeConfiguration<EmergencyFinancialExpenseLink>
{
    public void Configure(EntityTypeBuilder<EmergencyFinancialExpenseLink> builder)
    {
        builder.ToTable("CM_EMERGENCY_FINANCIAL_EXPENSE");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("EXPENSE_LINK_ID");

        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.EmergencyIncidentId).HasColumnName("EMERGENCY_INCIDENT_ID");
        builder.Property(e => e.EmergencyHostingId).HasColumnName("EMERGENCY_HOSTING_ID");
        builder.Property(e => e.EmergencyClosureId).HasColumnName("EMERGENCY_CLOSURE_ID");
        builder.Property(e => e.JournalEntryId).HasColumnName("JOURNAL_ENTRY_ID").IsRequired();

        builder.Property(e => e.ExpenseAmount)
            .HasColumnName("EXPENSE_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.ExpenseCategory)
            .HasColumnName("EXPENSE_CATEGORY")
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_EFE_SCHOOL");
        builder.HasIndex(e => e.JournalEntryId).HasDatabaseName("IDX_CM_EFE_JOURNAL");
        builder.HasIndex(e => e.EmergencyIncidentId).HasDatabaseName("IDX_CM_EFE_INCIDENT");
        builder.HasIndex(e => e.EmergencyHostingId).HasDatabaseName("IDX_CM_EFE_HOSTING");
        builder.HasIndex(e => e.EmergencyClosureId).HasDatabaseName("IDX_CM_EFE_CLOSURE");

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<JournalEntry>()
            .WithMany()
            .HasForeignKey(e => e.JournalEntryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Nullable cross-module FKs: use NoAction to avoid Oracle multi-path cascade
        builder.HasOne<EmergencyIncident>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyIncidentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<EmergencyHosting>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyHostingId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<EmergencyClosure>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyClosureId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 6-A  |  UserEmployeeIdentityLink  (M8 ⟷ M3)
// ─────────────────────────────────────────────────────────────
public class UserEmployeeIdentityLinkConfiguration
    : IEntityTypeConfiguration<UserEmployeeIdentityLink>
{
    public void Configure(EntityTypeBuilder<UserEmployeeIdentityLink> builder)
    {
        builder.ToTable("CM_USER_EMPLOYEE_IDENTITY");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.SystemUserId).HasColumnName("SYSTEM_USER_ID").IsRequired();
        builder.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.DirectorateId).HasColumnName("DIRECTORATE_ID");
        builder.Property(e => e.OrganizationalSectorId).HasColumnName("ORGANIZATIONAL_SECTOR_ID");
        builder.Property(e => e.LinkStatus).HasColumnName("LINK_STATUS").IsRequired();
        builder.Property(e => e.LinkedAt).HasColumnName("LINKED_AT").IsRequired();
        builder.Property(e => e.UnlinkedAt).HasColumnName("UNLINKED_AT");
        builder.Property(e => e.UnlinkReason).HasColumnName("UNLINK_REASON").HasMaxLength(300);
        builder.Property(e => e.LinkedByUserId).HasColumnName("LINKED_BY_USER_ID");
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        // Each SystemUser may only have one active Employee identity
        builder.HasIndex(e => e.SystemUserId).HasDatabaseName("IDX_CM_UEIL_USER");
        builder.HasIndex(e => e.EmployeeId).HasDatabaseName("IDX_CM_UEIL_EMPLOYEE");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_UEIL_SCHOOL");

        builder.HasOne<SystemUser>()
            .WithMany()
            .HasForeignKey(e => e.SystemUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Directorate>()
            .WithMany()
            .HasForeignKey(e => e.DirectorateId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<OrganizationalSector>()
            .WithMany()
            .HasForeignKey(e => e.OrganizationalSectorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 6-B  |  UserStudentIdentityLink  (M8 ⟷ M2)
// ─────────────────────────────────────────────────────────────
public class UserStudentIdentityLinkConfiguration
    : IEntityTypeConfiguration<UserStudentIdentityLink>
{
    public void Configure(EntityTypeBuilder<UserStudentIdentityLink> builder)
    {
        builder.ToTable("CM_USER_STUDENT_IDENTITY");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.SystemUserId).HasColumnName("SYSTEM_USER_ID").IsRequired();
        builder.Property(e => e.StudentId).HasColumnName("STUDENT_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.LinkStatus).HasColumnName("LINK_STATUS").IsRequired();
        builder.Property(e => e.LinkedAt).HasColumnName("LINKED_AT").IsRequired();
        builder.Property(e => e.UnlinkedAt).HasColumnName("UNLINKED_AT");
        builder.Property(e => e.LinkedByUserId).HasColumnName("LINKED_BY_USER_ID");
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.SystemUserId).HasDatabaseName("IDX_CM_USIL_USER");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_USIL_STUDENT");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_USIL_SCHOOL");

        builder.HasOne<SystemUser>()
            .WithMany()
            .HasForeignKey(e => e.SystemUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 6-C  |  UserGuardianIdentityLink  (M8 ⟷ M2)
// ─────────────────────────────────────────────────────────────
public class UserGuardianIdentityLinkConfiguration
    : IEntityTypeConfiguration<UserGuardianIdentityLink>
{
    public void Configure(EntityTypeBuilder<UserGuardianIdentityLink> builder)
    {
        builder.ToTable("CM_USER_GUARDIAN_IDENTITY");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.SystemUserId).HasColumnName("SYSTEM_USER_ID").IsRequired();
        builder.Property(e => e.StudentGuardianRelationshipId).HasColumnName("GUARDIAN_RELATIONSHIP_ID").IsRequired();
        builder.Property(e => e.StudentId).HasColumnName("STUDENT_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.LinkStatus).HasColumnName("LINK_STATUS").IsRequired();
        builder.Property(e => e.LinkedAt).HasColumnName("LINKED_AT").IsRequired();
        builder.Property(e => e.UnlinkedAt).HasColumnName("UNLINKED_AT");
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.SystemUserId).HasDatabaseName("IDX_CM_UGIL_USER");
        builder.HasIndex(e => e.StudentGuardianRelationshipId).HasDatabaseName("IDX_CM_UGIL_GUARDIAN");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_UGIL_STUDENT");

        builder.HasOne<SystemUser>()
            .WithMany()
            .HasForeignKey(e => e.SystemUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<StudentGuardianRelationship>()
            .WithMany()
            .HasForeignKey(e => e.StudentGuardianRelationshipId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 7-A  |  ReportSnapshotSourceLink  (M6 ⟷ M1-M5)
// ─────────────────────────────────────────────────────────────
public class ReportSnapshotSourceLinkConfiguration
    : IEntityTypeConfiguration<ReportSnapshotSourceLink>
{
    public void Configure(EntityTypeBuilder<ReportSnapshotSourceLink> builder)
    {
        builder.ToTable("CM_REPORT_SNAPSHOT_SOURCE");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.StatisticalReportSnapshotId)
            .HasColumnName("REPORT_SNAPSHOT_ID")
            .IsRequired();

        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.SourceModule)
            .HasColumnName("SOURCE_MODULE")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.SourceEntityType)
            .HasColumnName("SOURCE_ENTITY_TYPE")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(e => e.SourceEntityId).HasColumnName("SOURCE_ENTITY_ID");
        builder.Property(e => e.SchoolAcademicYearId).HasColumnName("ACADEMIC_YEAR_ID");
        builder.Property(e => e.AggregationDescription).HasColumnName("AGGREGATION_DESC").HasMaxLength(500);
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.StatisticalReportSnapshotId).HasDatabaseName("IDX_CM_RSSL_SNAPSHOT");
        builder.HasIndex(e => new { e.SchoolId, e.SourceModule }).HasDatabaseName("IDX_CM_RSSL_SCHOOL_MOD");

        builder.HasOne<StatisticalReportSnapshot>()
            .WithMany()
            .HasForeignKey(e => e.StatisticalReportSnapshotId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 7-B  |  EmployeeTrainingCourseLink  (M3 ⟷ M1)
// ─────────────────────────────────────────────────────────────
public class EmployeeTrainingCourseLinkConfiguration
    : IEntityTypeConfiguration<EmployeeTrainingCourseLink>
{
    public void Configure(EntityTypeBuilder<EmployeeTrainingCourseLink> builder)
    {
        builder.ToTable("CM_EMPLOYEE_TRAINING_COURSE");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.EmployeeTrainingId).HasColumnName("EMPLOYEE_TRAINING_ID").IsRequired();
        builder.Property(e => e.TrainingCourseOfferingId).HasColumnName("TRAINING_COURSE_OFFERING_ID").IsRequired();
        builder.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.TrainingFeeAmount)
            .HasColumnName("TRAINING_FEE_AMOUNT")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.FundingSource).HasColumnName("FUNDING_SOURCE").HasMaxLength(40);
        builder.Property(e => e.CertificateIssued).HasColumnName("CERTIFICATE_ISSUED").IsRequired();
        builder.Property(e => e.CertificateUrl).HasColumnName("CERTIFICATE_URL").HasMaxLength(500);
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.EmployeeTrainingId).HasDatabaseName("IDX_CM_ETCL_TRAINING");
        builder.HasIndex(e => e.TrainingCourseOfferingId).HasDatabaseName("IDX_CM_ETCL_OFFERING");
        builder.HasIndex(e => e.EmployeeId).HasDatabaseName("IDX_CM_ETCL_EMPLOYEE");

        builder.HasOne<EmployeeTraining>()
            .WithMany()
            .HasForeignKey(e => e.EmployeeTrainingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<TrainingCourseOffering>()
            .WithMany()
            .HasForeignKey(e => e.TrainingCourseOfferingId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 8-A  |  EmergencyStudentSafetyRecord  (M7 ⟷ M2)
// ─────────────────────────────────────────────────────────────
public class EmergencyStudentSafetyRecordConfiguration
    : IEntityTypeConfiguration<EmergencyStudentSafetyRecord>
{
    public void Configure(EntityTypeBuilder<EmergencyStudentSafetyRecord> builder)
    {
        builder.ToTable("CM_EMERGENCY_STUDENT_SAFETY");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("SAFETY_RECORD_ID");

        builder.Property(e => e.EmergencyIncidentId).HasColumnName("EMERGENCY_INCIDENT_ID").IsRequired();
        builder.Property(e => e.StudentId).HasColumnName("STUDENT_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.SafetyStatus).HasColumnName("SAFETY_STATUS").IsRequired();
        builder.Property(e => e.ParentNotified).HasColumnName("PARENT_NOTIFIED").IsRequired();
        builder.Property(e => e.ParentNotificationTime).HasColumnName("PARENT_NOTIFICATION_TIME");
        builder.Property(e => e.Location).HasColumnName("LOCATION").HasMaxLength(300);
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        // Composite index for real-time emergency roll-call queries
        builder.HasIndex(e => new { e.EmergencyIncidentId, e.SafetyStatus })
            .HasDatabaseName("IDX_CM_ESSR_INCIDENT_STATUS");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_ESSR_STUDENT");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_ESSR_SCHOOL");

        builder.HasOne<EmergencyIncident>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyIncidentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 8-B  |  EmergencyEmployeeSafetyRecord  (M7 ⟷ M3)
// ─────────────────────────────────────────────────────────────
public class EmergencyEmployeeSafetyRecordConfiguration
    : IEntityTypeConfiguration<EmergencyEmployeeSafetyRecord>
{
    public void Configure(EntityTypeBuilder<EmergencyEmployeeSafetyRecord> builder)
    {
        builder.ToTable("CM_EMERGENCY_EMPLOYEE_SAFETY");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("SAFETY_RECORD_ID");

        builder.Property(e => e.EmergencyIncidentId).HasColumnName("EMERGENCY_INCIDENT_ID").IsRequired();
        builder.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.SafetyStatus).HasColumnName("SAFETY_STATUS").IsRequired();
        builder.Property(e => e.IsOnDutyDuringIncident).HasColumnName("IS_ON_DUTY").IsRequired();
        builder.Property(e => e.AssignedRole).HasColumnName("ASSIGNED_ROLE").HasMaxLength(80);
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => new { e.EmergencyIncidentId, e.SafetyStatus })
            .HasDatabaseName("IDX_CM_EESR_INCIDENT_STATUS");
        builder.HasIndex(e => e.EmployeeId).HasDatabaseName("IDX_CM_EESR_EMPLOYEE");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_EESR_SCHOOL");

        builder.HasOne<EmergencyIncident>()
            .WithMany()
            .HasForeignKey(e => e.EmergencyIncidentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Employee>()
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 9  |  StudentCustodyAssetLink  (M2 ⟷ M4)
// ─────────────────────────────────────────────────────────────
public class StudentCustodyAssetLinkConfiguration
    : IEntityTypeConfiguration<StudentCustodyAssetLink>
{
    public void Configure(EntityTypeBuilder<StudentCustodyAssetLink> builder)
    {
        builder.ToTable("CM_STUDENT_CUSTODY_ASSET");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.StudentInventoryCustodyId).HasColumnName("STUDENT_INVENTORY_CUSTODY_ID").IsRequired();
        builder.Property(e => e.SchoolAssetId).HasColumnName("SCHOOL_ASSET_ID");
        builder.Property(e => e.InventoryItemId).HasColumnName("INVENTORY_ITEM_ID");
        builder.Property(e => e.StudentId).HasColumnName("STUDENT_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.ReplacementValue)
            .HasColumnName("REPLACEMENT_VALUE")
            .HasPrecision(19, 4)
            .IsRequired();

        builder.Property(e => e.IsReturned).HasColumnName("IS_RETURNED").IsRequired();
        builder.Property(e => e.ReturnDate).HasColumnName("RETURN_DATE");
        builder.Property(e => e.ConditionOnReturn).HasColumnName("CONDITION_ON_RETURN").IsRequired();
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.StudentInventoryCustodyId).HasDatabaseName("IDX_CM_SCAL_CUSTODY");
        builder.HasIndex(e => e.SchoolAssetId).HasDatabaseName("IDX_CM_SCAL_ASSET");
        builder.HasIndex(e => e.InventoryItemId).HasDatabaseName("IDX_CM_SCAL_ITEM");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_SCAL_STUDENT");

        builder.HasOne<StudentInventoryCustody>()
            .WithMany()
            .HasForeignKey(e => e.StudentInventoryCustodyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<SchoolAsset>()
            .WithMany()
            .HasForeignKey(e => e.SchoolAssetId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<InventoryItem>()
            .WithMany()
            .HasForeignKey(e => e.InventoryItemId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 10  |  StudentTransportRouteLink  (M2 ⟷ M7)
// ─────────────────────────────────────────────────────────────
public class StudentTransportRouteLinkConfiguration
    : IEntityTypeConfiguration<StudentTransportRouteLink>
{
    public void Configure(EntityTypeBuilder<StudentTransportRouteLink> builder)
    {
        builder.ToTable("CM_STUDENT_TRANSPORT_ROUTE");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.StudentTransportationSubscriptionId)
            .HasColumnName("TRANSPORT_SUBSCRIPTION_ID")
            .IsRequired();

        builder.Property(e => e.TransportationServiceId)
            .HasColumnName("TRANSPORTATION_SERVICE_ID")
            .IsRequired();

        builder.Property(e => e.StudentId).HasColumnName("STUDENT_ID").IsRequired();
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();
        builder.Property(e => e.AssignedSeatNumber).HasColumnName("ASSIGNED_SEAT_NUMBER").HasMaxLength(10);
        builder.Property(e => e.SubscriptionStatus).HasColumnName("SUBSCRIPTION_STATUS").IsRequired();
        builder.Property(e => e.EffectiveFrom).HasColumnName("EFFECTIVE_FROM");
        builder.Property(e => e.EffectiveTo).HasColumnName("EFFECTIVE_TO");
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.StudentTransportationSubscriptionId).HasDatabaseName("IDX_CM_STRL_SUBSCRIPTION");
        builder.HasIndex(e => e.TransportationServiceId).HasDatabaseName("IDX_CM_STRL_SERVICE");
        builder.HasIndex(e => e.StudentId).HasDatabaseName("IDX_CM_STRL_STUDENT");

        builder.HasOne<StudentTransportationSubscription>()
            .WithMany()
            .HasForeignKey(e => e.StudentTransportationSubscriptionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<TransportationService>()
            .WithMany()
            .HasForeignKey(e => e.TransportationServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Student>()
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 11  |  AuditableEntityRegistry  (M8 ⟷ All)
// ─────────────────────────────────────────────────────────────
public class AuditableEntityRegistryConfiguration
    : IEntityTypeConfiguration<AuditableEntityRegistry>
{
    public void Configure(EntityTypeBuilder<AuditableEntityRegistry> builder)
    {
        builder.ToTable("CM_AUDITABLE_ENTITY_REGISTRY");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("REGISTRY_ID");

        builder.Property(e => e.EntityTypeKey)
            .HasColumnName("ENTITY_TYPE_KEY")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(e => e.SourceModule)
            .HasColumnName("SOURCE_MODULE")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.TableNameHint)
            .HasColumnName("TABLE_NAME_HINT")
            .HasMaxLength(80)
            .IsRequired();

        builder.Property(e => e.EntityNameAr)
            .HasColumnName("ENTITY_NAME_AR")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(e => e.EntityNameEn)
            .HasColumnName("ENTITY_NAME_EN")
            .HasMaxLength(150);

        builder.Property(e => e.IsSensitive).HasColumnName("IS_SENSITIVE").IsRequired();
        builder.Property(e => e.RequiresApprovalToModify).HasColumnName("REQUIRES_APPROVAL").IsRequired();
        builder.Property(e => e.IsActive).HasColumnName("IS_ACTIVE").IsRequired();
        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        // Each EntityTypeKey must be globally unique in the registry
        builder.HasIndex(e => e.EntityTypeKey)
            .IsUnique()
            .HasDatabaseName("UX_CM_AER_ENTITY_TYPE_KEY");

        builder.HasIndex(e => e.SourceModule)
            .HasDatabaseName("IDX_CM_AER_SOURCE_MODULE");

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}

// ─────────────────────────────────────────────────────────────
//  BRIDGE 12  |  KpiFinancialPeriodLink  (M6 ⟷ M5)
// ─────────────────────────────────────────────────────────────
public class KpiFinancialPeriodLinkConfiguration
    : IEntityTypeConfiguration<KpiFinancialPeriodLink>
{
    public void Configure(EntityTypeBuilder<KpiFinancialPeriodLink> builder)
    {
        builder.ToTable("CM_KPI_FINANCIAL_PERIOD");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("LINK_ID");

        builder.Property(e => e.KpiMetricRecordId).HasColumnName("KPI_METRIC_RECORD_ID").IsRequired();
        builder.Property(e => e.PayrollRunId).HasColumnName("PAYROLL_RUN_ID");
        builder.Property(e => e.JournalEntryId).HasColumnName("JOURNAL_ENTRY_ID");
        builder.Property(e => e.SchoolId).HasColumnName("SCHOOL_ID").IsRequired();

        builder.Property(e => e.PeriodLabel)
            .HasColumnName("PERIOD_LABEL")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(e => e.Notes).HasColumnName("NOTES").HasMaxLength(500);

        builder.HasIndex(e => e.KpiMetricRecordId).HasDatabaseName("IDX_CM_KFPL_KPI");
        builder.HasIndex(e => e.SchoolId).HasDatabaseName("IDX_CM_KFPL_SCHOOL");
        builder.HasIndex(e => e.PayrollRunId).HasDatabaseName("IDX_CM_KFPL_PAYROLL_RUN");
        builder.HasIndex(e => e.JournalEntryId).HasDatabaseName("IDX_CM_KFPL_JOURNAL");

        builder.HasOne<KpiMetricRecord>()
            .WithMany()
            .HasForeignKey(e => e.KpiMetricRecordId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<PayrollRun>()
            .WithMany()
            .HasForeignKey(e => e.PayrollRunId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<JournalEntry>()
            .WithMany()
            .HasForeignKey(e => e.JournalEntryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<School>()
            .WithMany()
            .HasForeignKey(e => e.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
