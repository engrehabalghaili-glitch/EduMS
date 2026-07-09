using EduMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduMS.Infrastructure.M5_Finance.Configurations;

public class PayrollRunConfiguration : IEntityTypeConfiguration<PayrollRun>
{
    public void Configure(EntityTypeBuilder<PayrollRun> builder)
    {
        builder.ToTable("PAYROLL_RUN");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("PAYROLL_RUN_ID");

        builder.Property(p => p.RunNumber)
            .HasColumnName("RUN_NUMBER")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(p => p.RunNumber).IsUnique();

        builder.Property(p => p.Month)
            .HasColumnName("MONTH")
            .IsRequired();

        builder.Property(p => p.Year)
            .HasColumnName("YEAR")
            .IsRequired();

        builder.Property(p => p.ProcessDate)
            .HasColumnName("PROCESS_DATE")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.Status)
            .HasColumnName("STATUS")
            .IsRequired();

        // Audit Properties Configuration
        builder.Property(p => p.CreatedAt).HasColumnName("CREATED_AT").IsRequired();
        builder.Property(p => p.CreatedByUserId).HasColumnName("CREATED_BY_USER_ID").IsRequired();
        builder.Property(p => p.ModifiedAt).HasColumnName("MODIFIED_AT");
        builder.Property(p => p.ModifiedByUserId).HasColumnName("MODIFIED_BY_USER_ID");
        builder.Property(p => p.IsDeleted).HasColumnName("IS_DELETED").IsRequired();
        builder.Property(p => p.DeletedAt).HasColumnName("DELETED_AT");
        builder.Property(p => p.DeletedByUserId).HasColumnName("DELETED_BY_USER_ID");

        // Sync Properties Configuration
        builder.Property(p => p.VersionToken).HasColumnName("VERSION_TOKEN").IsRequired();
        builder.Property(p => p.SyncStatus).HasColumnName("SYNC_STATUS").IsRequired();
        builder.Property(p => p.LastSyncedAt).HasColumnName("LAST_SYNCED_AT");
    }
}
