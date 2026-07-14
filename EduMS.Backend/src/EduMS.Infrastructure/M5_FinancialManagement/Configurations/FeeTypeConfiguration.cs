using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_FinancialManagement.Configurations;

public class FeeTypeConfiguration : IEntityTypeConfiguration<FeeType>
{
    public void Configure(EntityTypeBuilder<FeeType> builder)
    {
        builder.ToTable("FEE_TYPE");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("ID");

        builder.Property(e => e.SchoolId)
            .HasColumnName("SCHOOL_ID")
            .IsRequired();

        builder.Property(e => e.GradeCapacityId)
            .HasColumnName("GRADE_CAPACITY_ID");

        builder.Property(e => e.FeeCode)
            .HasColumnName("FEE_CODE")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.FeeNameAr)
            .HasColumnName("FEE_NAME_AR")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.FeeNameEn)
            .HasColumnName("FEE_NAME_EN")
            .HasMaxLength(200);

        builder.Property(e => e.FeeCategory)
            .HasColumnName("FEE_CATEGORY")
            .IsRequired();

        builder.Property(e => e.Amount)
            .HasColumnName("AMOUNT")
            .HasColumnType("NUMBER(18,4)")
            .IsRequired();

        builder.Property(e => e.Currency)
            .HasColumnName("CURRENCY")
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.BillingFrequency)
            .HasColumnName("BILLING_FREQUENCY")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.IsTaxable)
            .HasColumnName("IS_TAXABLE")
            .IsRequired();

        builder.Property(e => e.TaxPercentage)
            .HasColumnName("TAX_PERCENTAGE")
            .HasColumnType("NUMBER(10,4)")
            .IsRequired();

        builder.Property(e => e.IsMandatory)
            .HasColumnName("IS_MANDATORY")
            .IsRequired();

        builder.Property(e => e.IsOptional)
            .HasColumnName("IS_OPTIONAL")
            .IsRequired();

        builder.Property(e => e.IsActive)
            .HasColumnName("IS_ACTIVE")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(e => e.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(e => e.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(e => e.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(e => e.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(e => e.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(e => e.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(e => e.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(e => e.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");

        builder.Ignore(e => e.DefaultAmount);
    }
}
